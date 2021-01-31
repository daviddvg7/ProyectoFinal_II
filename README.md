# Interfaces Inteligentes

## Proyecto Final Grupo

## Autores
-  Rafael Cala González - alu0101121901
-  Jorge Acevedo de León - alu0101123622
-  David Valverde Gómez - alu0101100296


## Índice   
1. [Introducción](#id1)
2. [Cuestiones importantes para el uso](#id2)
3. [Escenas](#id3)
4. [Hitos de programación](#id4)
5. [Aspectos a destacar](#id5)
6. [Acta de los acuerdos respecto al trabajo en equipo](#id6)

## Introducción<a name="id1"></a>

El **prototipo final** para la asignatura consiste en un juego en **Realidad Virtual** basado en la idea de las populares *scape room*, donde se está encerrado en una habitación y se deben resolver diferentes enigmas y desafíos para conseguir la combinación de la puerta que nos permitirá salir de ella. No obstante, no se ha seguido el diseño de las Scape Room clásicas, sino que hemos optado por hacer el diseño de los mapas enfocados a que cada sala te transporte a un lugar completamente diferente, a fin de darle variedad al juego y lograr que cada diseño se adecúe con lo que se quiere resolver.

Se han mezclado conceptos e ideas recabadas de los años de juegos que acumulamos entre los tres participantes del grupo, repensadas y refactorizadas para aportar una experiencia lo más fresca y novedosa posible.

Se partirá de una **escena principal** con diversas puertas que dirigen a diferentes salas, cada una con un desafío distinto, que utilizan elementos de **Unity** vistos en la asignatura, como brújulas, reconocimiento de voz o gestión de eventos.

Cada sala contará con un pequeño poema a modo de pista que indicará al usuario lo que debe hacer. Cuando se resuelve el desafío de una sala y se vuelve a la escena principal, la puerta relativa a la sala que acabamos de superar desaparecerá, y se mostrará una letra, una vez superadas todas las salas, aparecerá la puerta final, y las letras de cada puerta formarán una palabra que será la clave para abrirla y terminar el juego.

Un punto que vale la pena reseñar es que se ha tratado en todo momento de mantener un equilibrio entre seguir una intuitiva y orientativa interfaz de usuario y ser fiel a la idea de las Scape Room, donde prevalecen los enigmas y los rompecabezas. Así pues, cada detalle introducido en el juego trata de lograr exhaustivamente lo recientemente comentado.

## Cuestiones importantes para el uso<a name="id2"></a>

Se ha optado por utilizar la interfaz más natural posible para la interacción con el universo del juego; obligar al usuario a hacer uso de interfaces físicas para jugar dificulta en gran medida su capacidad de inmersión. Se busca que no solo sea sencillo, sino también accesible, por lo que la decisión final ha sido focalizar toda la interacción en el uso de la retícula, evitando así que el usuario se vea anclado al plano terrenal por un mando que sostener en la manos.

Así pues, apuntando la retícula en los elementos del escenario se activarán las interacciones con los objetos que en ese momento estén preparados para ello, de una forma simple e intuitiva. No se requiere que el usuario fije su visión en una parte en concreto, con que la retícula haga un contacto mínimo es suficiente en todos los casos.

De igual manera, para disfrutar completamente la experiencia, es bastante conveniente que el usuario pueda girar sobre sí mismo tanto para poder resolver cómodamente algunos de los niveles como para disponer de una visión total del mapa en el que se sitúa.

Otro aspecto importante a comentar es la necesidad del uso del micrófono, para lo cual se pide permisos de grabación al inicio de la aplicación.

## Escenas<a name="id3"></a>

### Menú de inicio

La primera escena que vemos al abrir el juego muestra un **menú inicial** que permite al usuario indicar cuándo desea comenzar a jugar, o salir de la aplicación si es lo que desea. Además, se indica el título y una pequeña 'puesta en situación' del juego.

[![Image from Gyazo](https://i.gyazo.com/6caeb6f655c11dbfc3bf18d32b772cfc.png)](https://gyazo.com/6caeb6f655c11dbfc3bf18d32b772cfc)

### Sala general

La **escena principal** del juego tiene lugar en un bosque un tanto tétrico durante la noche, se ve una pequeña *fogata* que aporta luz a la escena y se aprecian las **puertas** que dirigirán a cada desafío, además de la *pista* principal del juego, que indica que se deben realizar todos los desafíos para conseguir la clave y que aparezca la **puerta final**.

![Gif](Gifs/salaCentral1.gif)

Se tiene un total de **cuatro puertas** que, más la puerta final, proporcionarán las 5 letras que forman la clave necesaria para superar el juego.

![Gif](Gifs/salaCentral2.gif)

Como se venía diciendo, tras finalizar las cuatro salas, la palabra quedará visible y aparecerá la puerta final. Solo quedará decir en alto dicha palabra.

![Gif](Gifs/salaCentral3.gif)

### Recolección de libros

El jugador aparece en medio de una biblioteca, donde la primera pista le indica que debe recoger todos los libros rojos dispersos por la habitación. Para ayudar en la búsqueda, se tiene un contador que indica los restantes.

![Gif](Gifs/recoleccionLibros1.gif)
Una vez recogidos todos los libros, una de las estanterías se oculta para mostrar la puerta de retorno a la sala principal.

![Gif](Gifs/recoleccionLibros2.gif)

### Búsqueda de estrellas

Se muestra una playa durante la noche, con una pista en la arena que incita al jugador a buscar las estrellas en el norte. El jugador contará con una **brújula** que le indicará hacia que sentido está mirando, lo que le ayudará a encontrar el norte y, al levantar la vista al cielo, divisará, entre otras constelaciones, la *Osa Mayor*, la cual, una vez apuntada con la retícula, se iluminará de rojo y dará paso a la aparición de la puerta de regreso.

![Gif](Gifs/busquedaEstrellas.gif)

> **NOTA**: Este gif ha sido grabado desde una ejecución en ordenador, por lo que evidentemente la brújula no funciona correctamente.

### Figuras y colores

Se encuentra al jugador en medio del espacio, rodeado de figuras con forma de corazón, estrella y diamante, todas carentes de color. Se tienen 3 figuras, una de cada tipo y cada una de un color; el jugador debe 'tintar' la retícula con uno de estos colores y pintar cada una de las figuras en blanco del color que corresponda, respetando las equivalencias de las figuras grandes.

![Gif](Gifs/figurasColores1.gif)

Una vez completado, todas las figuras se teñirán de un color verde y aparecerá la puerta de salida.

![Gif](Gifs/figurasColores2.gif)

### Resolución de adivinanzas

En esta última sala, nos encontramos en una zona completamente oscura, en la cual se irán encendiendo varias llamas a modo de antorchas. El jugador comienza mirando hacia la pista, que le indica que debe resolver una adivinanza, cuya solución se debe decir en voz alta, mientras *devuelve fijamente la mirada*.

Esto puede resultar un poco confuso en un primer momento, hasta que el usuario busca por la escena y encuentra un ojo gigante mirándole fijamente, con la adivinanza a resolver bajo él.

Tras obtener la solución de la adivinanza, se debe mirar hacia el ojo y pronunciar en voz alta la respuesta. Si es correcta, el ojo desaparecerá y se activará la puerta de regreso.

![Gif](Gifs/adivinanza.gif)

## Hitos de programación<a name="id4"></a>

En relación a los contenidos que se han impartido, se han incluido los siguientes hitos:

### Modificación de las características físicas de los objetos

En diferentes salas se han implementado funciones que cambian cierta característica física de algunos objetos, como su color, o que directamente destruyen el objeto. 


### Eventos

Se implementan eventos que 
### Uso de Google VR

Como es lógico, se ha hecho uso de Google VR para el desarrollo del prototipo. En adición, se han modificado propiedades de la retícula a fin de 
### Animaciones

![Gif](Gifs/puertaAnimacion.gif)


### Iluminación

La iluminación juega un papel importante en algunas de las escenas. El caso más claro es el mapa de la playa, donde las constelaciones están creadas a partir de puntos de luz, de modo que los que forman la Osa Mayor, son modificados una vez encontrada dicha constelación. Así mismo, se utilizan hogueras y otros puntos de luz en el resto de mapas que ayudan a mejorar la experiencia.

### Sensores
  Para finalizar este apartado, cabe destacar el uso de sensores como:
  -  Brújula
  -  Micrófono (Reconocimiento de voz)
  -  Salida de audio (Reproducción de sonidos)
  
  De esto se hablará en detalle en el apartado siguiente.

## Aspectos a destacar<a name="id5"></a>

En este proyecto destacan diferentes aspectos que se consideran de interés para la experiencia de usuario en una aplicación de *Realidad Virtual*:

* Se cuenta con una **pantalla principal** bastante sencilla, pero que da al usuario la oportunidad de iniciar el juego cuando lo desee.

* No se utilizan **colores brillantes** que puedan molestar al usuario.

* Se ha hecho uso de numerosos **assets** de Unity con el fin de conseguir escenas lo más realistas e inmersivas posible.

* Existen diferentes **animaciones** que aportan cierto realismo y dinamismo al juego.

* También se han implementado diferentes **sonidos**, tanto de fondo como cuando se cumple algún objetivo. 

Además, se han incluido diversos **sensores** trabajados a lo largo de la sección de *Interfaces Multimodales*:

* La **brújula** del dispositivo móvil es utilizada en la sala de *Búsqueda de estrellas*, indica al usuario hacia dónde está mirando y le ayuda a localizar la *Osa Mayor* que se encuentra en el *norte*. Esto se ha conseguido gracias a *Input.compass*.

* Se ha implementado la **reproducción de sonidos** en todas las salas, bien como sonido ambiente o bien activados por la consecución de alguno de los objetivos propuestos. Esto ha sido posible gracias al elemento *Audio Source*, que ha sido añadido a diferentes objetos en todas las escenas, además de los *Audio Clips* que definen el sonido a reproducir.

![Imagen](Imagenes/audio1.png)
![Imagen](Imagenes/audio2.png)


* El **reconocimiento de voz** se utiliza en diversos momentos del juego:
  - En la sala de *Resolución de adivinanzas* se requiere al jugador que dia en voz alta la respuesta, esto será transformado a texto y se verificará si es la respuesta.
  - En la *sala principal*, una vez superados todos los desafíos y aparezca la **puerta final**, la clave para abrirla también debe ser dicha en voz alta. 

Cabe destacar que, dado que el reconocimiento de voz visto en clase (*Keyword Recognizer*) utiliza una librería de Windows, no es posible implementarlo en una aplicación móvil, por lo que se ha utilizado la librería *SpeechToText*, que permite convertir la voz a texto (y viceversa) tanto en dispositivos **Android** como **IOS**. 


## Acta de los acuerdos respecto al trabajo en equipo<a name="id6"></a>


