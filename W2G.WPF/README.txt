Cahier des charges :

- [~] 1. CRUD sur 3/4 tables différentes
	- Table Unit :
		- [ ] Création
		- [X] Lecture
		- [ ] Modification
		- [X] Suppression
	- Table Bay :
		- [ ] Création
		- [X] Lecture
		- [X] Modification
		- [X] Suppression
	- Table Interventions :
		- [ ] Création
		- [X] Lecture
		- [X] Modification
		- [X] Suppression
	- Table Type :
		- [ ] Création
		- [X] Lecture
		- [X] Modification
		- [X] Suppression
	- Table State :
		- [ ] Création
		- [X] Lecture
		- [X] Modification
		- [X] Suppression
	- Table Usage :
		- [ ] Création
		- [X] Lecture
		- [X] Modification
		- [X] Suppression

- [X] 2. Gestion des droits et deux profils différents (technicien/comptable)
	- [X] 2.0 Customer			(compte : antonin@antonin.com	| mdp : testtest (mot de passe pré-rempli))
	- [X] 2.1 Technicien		(compte : tech@tech.com			| mdp : testtest (mot de passe pré-rempli))
	- [X] 2.2 Comptable			(compte : compta@compta			| mdp : testtest (mot de passe pré-rempli))
	- [X] 2.3 Administrateur	(compte : admin@admin			| mdp : testtest (mot de passe pré-rempli))

- [~] 3. Des fonctions de recherche, de modification et de suppression multiple
	- Table Unit : 
		- [X] 3.1 Recherche par nom
		- [X] 3.2 Recherche par baie
		- [X] 3.3 Recherche par état
		- [X] 3.4 Recherche par utilisation
		- [ ] 3.5 Modification multiple
		- [ ] 3.6 Suppression multiple
	- Table Bay :
		- [X] 3.7 Recherche par nom (Seule recherche utile possible)
		- [ ] 3.8 Modification multiple
		- [ ] 3.9 Suppression multiple
	- Table Interventions :
		- [X] 3.10 Recherche par nom
		- [X] 3.11 Recherche par type
		- [X] 3.12 Recherche par unité
		- [ ] 3.13 Modification multiple
		- [ ] 3.14 Suppression multiple
	- Table Type :
		- [X] 3.15 Recherche par type
		- [ ] 3.16 Modification multiple
		- [ ] 3.17 Suppression multiple
	- Table State :
		- [X] 3.18 Recherche par état
		- [ ] 3.19 Modification multiple
		- [ ] 3.20 Suppression multiple
	- Table Usage :
		- [X] 3.21 Recherche par utilisation
		- [ ] 3.22 Modification multiple
		- [ ] 3.23 Suppression multiple

- [ ] 4. Des validators avancés (représentant des fonctions et logiques métiers)
	- [X] 4.1 Bay :
		- [X] 4.1.1 Validation de la reference
	- [X] 4.2 Intervention :
		- [X] 4.2.1 Validation du titre
		- [X] 4.2.2 Validation de la description
		- [X] 4.2.3 Validation de la date
		- [X] 4.2.4 Validation du type
	- [X] 4.3 State :
		- [X] 4.3.1 Validation de l'état
	- [X] 4.4 Type :
		- [X] 4.4.1 Validation du type
	- [X] 4.5 Unit :
		- [X] 4.5.1 Validation de la reference
		- [X] 4.5.2 Validation de la baie et de sa taille
		- [X] 4.5.3 Validation de l'état
		- [X] 4.5.4 Validation de l'utilisation
	- [X] 4.6 Usage :
		- [X] 4.6.1 Validation du type
		- [X] 4.6.2 Validation de la couleur

Ne marche pas :

- La création sur toutes les tables
- La modification de Unit

Pour les problèmes de création et de modification c'est parce que la vérification d'erreur n'actualialise pas la disponibilité du bouton

- Les filtres (BayFilter, InterventionFilter), donc les boards qui sont dans les forms (BayForm, UnitForm) ne sont pas bien filtrées

WIP :

- Les boards en dehors de Tech ne sont pas encoré implémentées
- Les tests unitaires ne fonctionnent pas encore tous