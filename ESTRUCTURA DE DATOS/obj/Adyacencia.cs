#include <stdio.h>

#define MAX_NODOS 10  // Definir el número máximo de nodos

// Función para inicializar la matriz de adyacencia
void inicializarMatriz(int matriz[MAX_NODOS][MAX_NODOS], int nodos) {
    for (int i = 0; i < nodos; i++) {
        for (int j = 0; j < nodos; j++) {
            matriz[i][j] = 0;
        }
    }
}

// Función para agregar una arista entre dos nodos
void agregarArista(int matriz[MAX_NODOS][MAX_NODOS], int nodo1, int nodo2) {
    matriz[nodo1][nodo2] = 1;
    matriz[nodo2][nodo1] = 1;  // Grafo no dirigido
}

// Función para mostrar la matriz de adyacencia
void mostrarMatriz(int matriz[MAX_NODOS][MAX_NODOS], int nodos) {
    printf("Matriz de Adyacencia:\n");
    for (int i = 0; i < nodos; i++) {
        for (int j = 0; j < nodos; j++) {
            printf("%d ", matriz[i][j]);
        }
        printf("\n");
    }
}

// Función para mostrar las conexiones entre nodos
void mostrarConexiones(int matriz[MAX_NODOS][MAX_NODOS], int nodos, char *nombres[]) {
    printf("\nConexiones entre nodos:\n");
    for (int i = 0; i < nodos; i++) {
        printf("%s está conectado con: ", nombres[i]);
        int primerConexión = 1;
        for (int j = 0; j < nodos; j++) {
            if (matriz[i][j] == 1) {
                if (primerConexión) {
                    printf("%s", nombres[j]);
                    primerConexión = 0;
                } else {
                    printf(", %s", nombres[j]);
                }
            }
        }
        printf("\n");
    }
}

int main() {
    // Definir los nodos
    char *nombres[] = {"A", "B", "C", "D"};
    int nodos = 4;

    // Crear la matriz de adyacencia
    int matriz[MAX_NODOS][MAX_NODOS];
    inicializarMatriz(matriz, nodos);

    // Agregar algunas aristas
    agregarArista(matriz, 0, 1);  // A-B
    agregarArista(matriz, 0, 2);  // A-C
    agregarArista(matriz, 1, 3);  // B-D

    // Mostrar la matriz de adyacencia
    mostrarMatriz(matriz, nodos);

    // Mostrar las conexiones
    mostrarConexiones(matriz, nodos, nombres);

    return 0;
}
