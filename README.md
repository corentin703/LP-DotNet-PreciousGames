# Precious Games

## Auteurs :
- Nicolas MORIN
- Corentin VÉROT

## Applications :

### Console :

Application très basique ajoutant un genre, un étideur et un jeu à la base de donnée.

### Client lourd WPF : 

Application permettant de visualiser une liste de jeux, d'en ajouter et d'en éditer.

### Application Web ASP.NET MVC :

Application web permettant d'ajouter, d'éditer, de supprimer et de visualiser :
- des éditeurs
- des genres / types de jeu
- des jeux
- des expériences utilisateur
- des évaluations

Une recherche de jeux est aussi implémentée : le contenu de la liste de jeux est actualisée grâce 
à une requête AJAX retournant une vue partielle.

Les contrôleurs des expériences et des évaluations font l'objet d'une route spécifique aux contrôleurs d'entités dépendant des jeux.

La page d'accueil montre deux tableaux affichant chacun :
- les 5 jeux les mieux notés
- les 5 dernières évaluations ajoutées

La validation des divers formulaires est réalisée grâce au *model binding*.

### Projet de tests : 
Un projet de tests est disponible pour le Business Layer (BusinessLayer.Tests). 
Celui-ci se concentre sur le test des requêtes liées aux jeux.