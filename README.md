> Observing CNAMS ! <
Une démo de jeu où vous êtes une poupoule, venue de contrées loitaines afin d'observer des oiseaux rares : les CNAMS. ♥
Attention tout de même à ne pas tomber des plateformes, même si la neige armoti la chute ~

--
Mesdames et Messieurs, 

Pour mon projet, j'ai décidé de faire une petite démo,
n'ayant pas encore les connaissances nécéssaires et souhaitant me concentrer, pour ce projet, sur mes boids.
Après avoir lu le cours du professeur - j'ai fait un premier test sur une scène vide,
afin de voir et de mieux comprendre le fonctionnement de ceux-ci (leur comportement, les forces et zones de cohésion, d'attraction et d'alignement, etc).

Bien que j'ai toujours quelques difficultés et que je vais encore par la suite reprendre ce cours afin d'en décortiquer les étapes davantage,
en recréant des nouvelles démos ou projet de jeux, j'ai pu comprendre dans la globalité ce qu'on attendait de ces boids et comment contrôler un petit peu, ce qui les rends si spéciaux.

J'ai donc, en utilisant à la fois le début du cours et la suite, créé dans ma démo une cible, invisible dans le jeu, que mes boids suivent - mais tout en leur laissant un peu de liberté de mouvement.
J'avais en effet au début utilisé velocity.y pour faire en sorte que ceux-ci n'aillent pas en dessous de mon terrain, mais cela les empêchait d'aller vers le bas tout simplement et ce n'était donc absolument pas optimal.
Mes boids dérivaient vers d'autres cieux et ne revenaient que de manière aléatoire, selon les forces qui s'appliquaient à eux, car velocity est le vecteur3 et non la position, ce que j'avais au départ confondu.

En le retravaillant alors, et grâce à des explications complémentaires et précieuses de M. Guillaume Patrice (sur les vecteurs, ou encore des actions simples sur unity comme par exemple l'option de "unpack" pour un prefab),
aussi en phase d'inscription au CNAM, j'ai pu créer une cible qui se déplace dans des positions "random" (aléatoires),
dans un périmètre de 30 mètres par rapport à sa position de départ, afin que les boids, qui le suivent, ne puissent pas s'échapper hors de ma scène et finir on ne sait où en dessous de celle-ci ou au dessus.

En résumer :
Les mouvements de mes boids sont donc à la fois aléatoires dans ma démo, mais sous contrôle de ma cible invisible,
elle-même ayant des déplacements aléatoires mais dans un périmètre de contrôle de 30 mètre de sa position initiale. De plus, j'ai ajouté à ma caméra des scripts la permettant de bouger avec la souris pour que ma poule, appelée Enjmin,
puisse observer ses si beaux CNAMS tout en se baladant sur des plateformes de glace.

J'espère que mon projet vous plairas et j'ai hâte d'en apprendre plus et de m'améliorer par la suite.
Merci à vous pour votre travail et votre temps.

Bien à vous,
Mme Aveillan Diane

--
Update 2022/05/24 : originally, the demo was a game in which you had to find treasures on the platforms to win and not fall. I didn't have time to finish it and had to learn a lot of things too, so it became a demo. But this is why the original name was CNAMazingHunt / CNAMamazingHunt3D and you can still see it while browsing the files. ^-^
