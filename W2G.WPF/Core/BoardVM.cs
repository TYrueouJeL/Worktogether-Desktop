using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using W2G.EF;

namespace W2G.WPF.Core
{
    public interface IBoardControl<E> where E : WtgEntity, new()
    {
        BoardVM<E> VM { get; }
        public E SelectedItem
            => VM.SelectedItem;

        void ReloadSource()
            => VM.ReloadSource();

        public void DGrdMDC()
        {
            if (VM.ChooseCommand.CanExecute(null))
            {
                VM.ChooseCommand.Execute(null);
            }
            else if (VM.EditCommand.CanExecute(null))
            {
                VM.EditCommand.Execute(null);
            }
        }
    }

    public class BoardVM<E> : EntityVM<E> where E : WtgEntity, new()
    {
        #region Source
        public ObservableCollection<EntityPresentation<E>> ItemsSource { get; private set; }

        public virtual void ReloadSource()
        {
            ItemsSource = new ObservableCollection<EntityPresentation<E>>();
            Controller.DbSet.ToList().ForEach(FilterSearchPresent);
            OnPropertyChanged(nameof(ItemsSource));
        }

        private void FilterSearchPresent(E item)
        {
            if (FilterFunc?.Invoke(item) ?? true)
            {
                bool search = false;

                if (string.IsNullOrEmpty(SearchText))
                {
                    search = true;
                }
                else
                {
                    if (SearchFunc != null)
                    {
                        search = SearchFunc(SearchText, item);
                    }
                    else
                    {
                        search = item.MatchSearch(SearchText);
                    }
                }

                if (search)
                {
                    ItemsSource.Add(Controller.GetPresentedEntity(item));
                }
            }
        }
        #endregion

        private EntityPresentation<E> _SelectedItem = null;
        public EntityPresentation<E> SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }

        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
                OnPropertyChanged();
            }
        }
        public Func<E> DefaultEntityFunc { get; set; }

        public Action<E> CreateAction { get; set; }
        public Action<E> EditAction { get; set; }
        public Action<E> DestroyAction { get; set; }
        public Action<E> ChooseAction { get; set; }

        public Func<E, bool> FilterFunc { get; set; }
        public Func<string, E, bool> SearchFunc { get; set; }

        public ICommand SearchCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DestroyCommand { get; }
        public ICommand ChooseCommand { get; }

        public BoardVM(EntityController<E> controller, EBoardMode mode, string search)
            :base(controller)
        {
            SearchCommand = new RelayCommand(() => ReloadSource());

            CreateCommand = new RelayCommand(() =>
            {
                if (CreateAction == null)
                {
                    Controller.CreateEntity(DefaultEntityFunc?.Invoke() ?? new E());
                }
                else
                {
                    CreateAction(DefaultEntityFunc?.Invoke() ?? new E());
                }

                ReloadSource();
            }, CanCreate);

            EditCommand = new RelayCommand(() =>
            {
                if (EditAction == null)
                {
                    Controller.EditEntity(_SelectedItem);
                }
                else
                {
                    EditAction(_SelectedItem);
                }

                ReloadSource();
            }, CanEdit);

            DestroyCommand = new RelayCommand(() =>
            {
                if (DestroyAction == null)
                {
                    Controller.DestroyEntity(_SelectedItem);
                }
                else
                {
                    DestroyAction(_SelectedItem);
                }

                ReloadSource();
            }, CanDestroy);

            ChooseCommand = new RelayCommand(() =>
            {
                if (ChooseAction != null)
                {
                    ChooseAction(_SelectedItem);
                }
            }, CanChoose);

            _SearchText = search;
            OnPropertyChanged("SearchText");

            ReloadSource();
        }

        public virtual bool CanCreate()
        {
            return true;
        }
        public virtual bool CanEdit()
        {
            return _SelectedItem != null;
        }
        public virtual bool CanDestroy()
        {
            return _SelectedItem != null;
        }

        public virtual bool CanChoose()
        {
            return ChooseAction != null && SelectedItem != null;
        }
    }
}
