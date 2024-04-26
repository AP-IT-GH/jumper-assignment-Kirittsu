# jumper-assignment
Afissou Arigbe s127856

Keanu Segers s131155

In dit document bespreken we hoe onze resultaten hebben behaald, en hoe we onze agent hebben getrained.
## Installatie

Voor onze opdracht hebben we de 2022.3.10f1 unity versie gebruikt met de ML Agents 2.0.1 package.
Voor onze training hebben we de anaconda environment gebruikt met ML Agents 0.30.0 en pytorch 1.7.1

## Training environment

![image](https://github.com/AP-IT-GH/jumper-assignment-Kirittsu/assets/91462909/df27e93b-6eb3-42f4-bef8-9ee2508925c4)

Onze training environment bestaat uit 2 banen, 2 muren en 2 spawners.
Vanuit 2 richtingen komen uit de spawners obstakels waar de agent over moet springen.
Zodra een obstakel de agent of een muur raakt wordt die verwijderd.

**Obstakel:**

![image](https://github.com/AP-IT-GH/jumper-assignment-Kirittsu/assets/91462909/c670d32c-f575-4687-b35f-18a81f7feb80)

De obstakels hebben een eigen script voor beweging en snelheid(zie obstacle script in assets). De spawner bepaalt de frequentie van de obstakels(zie Spawner script in assets).

## Scripts

### spawner

Op het einde van elke baan zit een spawner, die gebruiken volgende [script](https://github.com/AP-IT-GH/jumper-assignment-Kirittsu/blob/main/Assets/Scripts/Spawner.cs).
Vergeet niet de obstacle prefab te assignen. Aan beide spawners hebben we een min cooldown van 2 en max cooldown van 5 gegeven.

### obstacle

De obstacles gebruiken volgende [script](https://github.com/AP-IT-GH/jumper-assignment-Kirittsu/blob/main/Assets/Scripts/Obstacle.cs).
Voor het obstakel in de spawner die niet gedraait is hebben we een Z speed van 0.5 en rotation van 90 gegeven. Het andere obstakel heeft een x speed van -O.5 meegekregen.
Voor het obstakel script is het belangerijk dat de muren een "Wall" tag en de agent een "Agent" tag krijgen. 

### Agent
De Agent heeft het volgende [script](https://github.com/AP-IT-GH/jumper-assignment-Kirittsu/blob/main/Assets/Scripts/Jumper.cs).
Als parameters voor het jumper script hebben we Jump Force van 20 en Gravity Scale 7. Vergeet niet de banen een layer te geven en die dan als ground te zetten voor het jumper script.

## Training Resultaten

**tensorboard grafieken**

![image](https://github.com/AP-IT-GH/jumper-assignment-Kirittsu/assets/91462909/991a4036-bd68-41f7-b640-79b14f0243fb)

Dit zijn onze behaalde resultaten met de gegeven parameters. We hebben hiervoor met verschillende waardes en variaties van scripts getest en getrained met gelijke of slechtere resultaten. Dit wijst ons dat er veranderingen moeten gebeuren aan de jumper script of andere parameters.


