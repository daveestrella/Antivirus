# Antivirus
Ejercicio de proframación

Antivirus

Las técnicas de Machine Learning se aplican a muchos campos, incluyendo la detección de virus informáticos. En esta oportunidad analizaremos los datos producidos por C.C. (Company of Capital Consumption).  Los archivos de C.C.C. están dispuestos en posiciones contiguas. En cada posición hay un conjunto de celdas con registros. Podemos imaginar estos registros como una lista de listas (Lista de archivos en este caso). 

 

Es bien sabido que existe un virus que infectará el sistema, y este virus en particular tiene una forma muy especial de infectar los archivos. Utilizando algunas heurísticas se ha detectado que existen dos versiones del virus (tipo A y tipo B). El virus comienza a infectar archivos de izquierda a derecha, en otras palabras, siempre comienza con el registro en la posición más a la izquierda y sigue moviéndose hacia la derecha.

El virus tipo A selecciona una posición inicial i y comienza a consumir registros desde esa posición y forma una especie de triángulo (siempre forma el triángulo más grande posible). Podemos mostrar el crecimiento del virus con el siguiente gráfico: 

Sea la posición inicial = 2 (Los glóbulos rojos son los registros infectados). El virus tipo A no infectará más registros porque no puede crecer más (no hay más registros arriba, para extender el triángulo).



 


Otro ejemplo: sea la posición inicial = 4
El virus tipo A no infectará más registros porque no hay más registros gratuitos a la derecha. 



 
En resumen, el virus tipo A intenta formar un triángulo centrado en la posición inicial i, el triángulo debe estar completo (sin partes faltantes). Cada archivo j ubicado en la parte superior de la posición debe tener un registro infectado menor que el archivo en la posición j + 1.
Análogamente, cada archivo j ubicado en la posición inferior debe tener un registro infectado menor que el archivo en la posición j-1. 




El virus tipo B actúa de manera similar, selecciona una posición inicial i y comienza a consumir registros desde esa posición y forma una especie de triángulo incompleto (siempre forma el triángulo incompleto más grande posible). 

Podemos mostrar el crecimiento del virus tipo B con el siguiente gráfico: 

Sea la posición inicial = 2 (los glóbulos rojos son registros infectados)
El virus tipo B no infectará más registros porque no hay más registros gratuitos a la derecha.



 



Otro ejemplo: Sea la posición inicial = 4 
El virus tipo B no infectará más registros porque no hay más registros libres a la derecha. 




 



En resumen, el virus tipo B intenta formar un triángulo incompleto centrado en la posición inicial i. Se entiende que las partes incompletas se refieren a la parte superior e inferior del triángulo. La esquina que crece de izquierda a derecha siempre debe estar completa. Cada archivo j ubicado en la posición superior debe tener un registro infectado menor que el archivo en la posición j + 1. Análogamente, cada archivo j ubicado en la posición inferior debe tener un registro infectado menor que el archivo en la posición j-1. 

Al saber cómo se expande el virus, queremos saber cuántos registros no se infectarán en un cierto rango (nos referimos al rango de archivos infectados).

Entrada

La entrada puede contener varios casos de prueba. Cada caso de entrada comienza con una línea que contiene N (1 ≤ N ≤ 5 * 105), la cantidad de archivos. La siguiente línea contiene N enteros 
ri (1 ≤ i ≤ N y 1 ≤ ri ≤ 109), la cantidad de registros de cada archivo. Luego viene un número entero 
Q (1 ≤ Q ≤ 5 * 105), el número de consultas. Después de eso, siguen las líneas Q, especificando las consultas en el siguiente formato: 

• 1 i val = Reemplazar el elemento en la posición i (1 ≤ i ≤ N) con el valor val (1 ≤ val ≤ 109) 
• 2 i type = del total de registros de los archivos infectados, calcule cuántos registros no se infectarán si el virus comienza a infectar el archivo i. Un archivo se considera infectado si tiene al menos un registro infectado. 

Para cada consulta de tipo 2, debe suponer que el sistema no está infectado. El tipo de variable indica el tipo de virus. Si tipo = 1 el virus es de tipo A, en otro caso el virus es de tipo B. En todos los casos, debe suponer que la propagación durará al menos ri días (el virus infectará la cantidad máxima posible de archivos).

Salida

Para cada consulta de tipo 2, imprima una sola línea con dos enteros: la cantidad máxima de registros infectados (de los archivos infectados) y la cantidad de registros que no están infectados. Vea el ejemplo de entrada y salida para más detalles. 

Explicación:
En la primera consulta, el tipo de virus es B, por lo tanto, se extiende hasta infectar todos los registros del archivo 6. Los archivos 5, 6 y 7 están infectados. Un registro del archivo 5, dos registros del archivo 6 y un registro del archivo 7 están infectados. Por lo tanto, (6-1) + (2-2) + (5-1) = 9 registros no infectados permanecen. 

En la segunda consulta, el tipo de virus de tipo A crece de la misma manera que la primera consulta. 

En la tercera consulta, el virus de tipo B se expande hasta que consume 4 registros del archivo 4. El virus ya no progresa porque no hay registros para infectar en el archivo 6 (sus dos registros ya han sido infectados). 

En la cuarta consulta, el virus de tipo A crece de la misma manera que la tercera consulta. 

En la quinta consulta, cambiamos el elemento en la posición 6 con el valor 6. 

En la sexta consulta, los archivos [1. . . 11] se infectan. La cantidad de registros infectados es: 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1. El máximo es 6. 14 registros permanecen no infectados. 

En la séptima consulta, el virus A crece de la misma manera que la última consulta. 

En la octava consulta, el tipo de virus B consume todos los registros del archivo 4. Los archivos [1. . . 8] se infectan y la cantidad de registros infectados es: 2, 3, 4, 5, 4, 3, 2, 1. El máximo es 5. 14 registros permanecen no infectados. 

En la novena consulta, el virus tipo A infecta 4 registros del archivo 4. Después de eso, ya no puede expandirse. El máximo es 4. Archivos [1. . . 7] están infectados. 18 registros permanecen no infectados.


Entrada de muestra

12 
3 4 5 5 6 2 5 4 3 2 1 1 
9 
2 6 0 
2 6 1 
2 4 0 
2 4 1 
1 6 6 
2 6 0 
2 6 1 
2 4 0 
2 4 1 

Salida de Muestra
2 9 
2 9 
4 14 
4 14 
6 8 
6 8 
5 14 
4 18

