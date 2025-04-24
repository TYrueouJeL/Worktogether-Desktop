using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using W2G.EF;

namespace W2G.WPF.Core
{
    public abstract class EntityPresentation<E> : EntityVM<E>, INotifyDataErrorInfo
        where E : WtgEntity, new()
    {
        public E Entity { get; set; }

        public ICommand SaveCommand { get; }

        public ICommand ResetCommand { get; }

        public ICommand HelpCommand { get; }

        public Action OnSave { get; set; }

        protected EntityPresentation(EntityController<E> controller, E entity)
            : base(controller)
        {
            Entity = entity;
            _Errors = new Dictionary<string, List<string>>();

            SaveCommand = new RelayCommand(() =>
            {
                if (SaveFields())
                {
                    if (IsNew())
                    {
                        if (Controller.InsertEntity(Entity))
                        {
                            OnSave?.Invoke();
                        }
                    }
                    else
                    {
                        if (Controller.UpdateEntity(Entity))
                        {
                            OnSave?.Invoke();
                        }
                    }
                }
            }, () => !HasErrors);

            ResetCommand = new RelayCommand(ResetFields);

            HelpCommand = new RelayCommand(ShowHelp);

            ResetFields();
        }

        public bool IsNew() => Entity.IsNew();

        public virtual void ClearAndNotify([CallerMemberName] string propertyName = null)
        {
            ClearErrors(propertyName);
            OnPropertyChanged(propertyName);
        }

        public abstract bool SaveFields();
        public abstract void ResetFields();

        public virtual void ShowHelp()
        {
            if (HasErrors)
            {
                var msg = "";

                foreach (KeyValuePair<string, List<string>> kvp in _Errors)
                {
                    msg += "\r\n" + kvp.Key + " : ";
                    if (kvp.Value.Count == 0)
                        msg += "Aucune erreur";
                    else
                    {
                        msg += kvp.Value.Count + " erreur(s)";
                        foreach (var item in kvp.Value)
                        {
                            msg += "\r\n\t" + item;
                        }
                    }


                }

                MessageBox.Show(msg, "Aide", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                MessageBox.Show("Aucune erreur", "Aide", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region NDEI
        private Dictionary<string, List<string>> _Errors { get; }

        public bool HasErrors => _Errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void AddError(string propertyName, string error)
        {
            if (!_Errors.ContainsKey(propertyName))
            {
                _Errors[propertyName] = new List<string>();
            }
            if (!_Errors[propertyName].Contains(error))
            {
                _Errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors([CallerMemberName] string propertyName = null)
        {
            if (_Errors.ContainsKey(propertyName))
            {
                _Errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        public IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            if (_Errors.ContainsKey(propertyName))
            {
                return _Errors[propertyName];
            }
            else
            {
                return null;
            }
        }
        #endregion

        public static implicit operator E(EntityPresentation<E> presentation) => presentation?.Entity;
    }
}
