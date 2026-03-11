# Practica1JorgeGarciaSanz
Primera practica de la asignatura

PlayerControler: Básicamente lee las teclas (flechas/WASD) para mover al personaje por el suelo (en XZ). Para el salto usa el Rigidbody: cuando pulsas Space, primero comprueba si estás tocando el suelo (isGrounded, que se actualiza con colisiones con objetos tag Ground) y solo entonces te deja saltar, así no puedes spamear saltos en el aire. Y si activas lo del doble salto, te deja pegar un segundo salto en el aire una única vez.

FallingPlatform: Esta plataforma “se activa” cuando el jugador se sube encima (y no si le das de lado). Cuando detecta que el Player está arriba, empieza una cuenta atrás con Time.time y esa cuenta sigue aunque te bajes. Al terminar, la plataforma baja a una velocidad fija hasta una altura mínima (minY), se queda un momento parada y luego vuelve a su posición inicial, dejándolo todo reseteado para que funcione otra vez igual.

MovingPlantform: Aquí la plataforma va y vuelve entre dos puntos: su posición inicial y la posición de un objeto destino que usas como marcador (y que se hace invisible). En FixedUpdate se mueve con MoveTowards a velocidad constante y cuando llega “casi” al destino cambia el sentido para volver, y así en bucle. Se mueve con rb.MovePosition porque es lo más decente para mover cosas con Rigidbody sin que la física se vuelva loca.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Segunda práctica

Se añadieron monedas, vidas, respawn y la UI para mostrarlas en el Canvas.

Monedas

Coleccionable: Script de las monedas (Collider con Is Trigger). Cuando entra el Player (tag Player), llama a GameManagerClase.addMoneda() y destruye la moneda.

GameManagerClase: Guarda las monedas y lanza un evento cuando cambian para que la UI se actualice.
Awake() es un método que Unity ejecuta antes que Start(), nada más cargar el objeto en la escena. En este caso lo uso en el GameManagerClase para que el Singleton (instancia) se cree lo antes posible y así la UI y el resto de scripts puedan usar GameManagerClase.instancia sin que sea null. También es buen sitio para inicializar valores importantes como vidas = vidasIniciales y para hacer DontDestroyOnLoad(gameObject) (para que el GameManager no se destruya al cambiar de escena).

Vidas y daño (pinchos)

DamageZone (Pinchos): Los pinchos tienen Collider con Is Trigger y cuando el Player los toca, llaman a GameManagerClase.LoseLife() para restar una vida.

GameManagerClase: Tiene vidasIniciales (configurable en el Inspector) y vidas actuales. Cuando el jugador recibe daño:

Si quedan vidas, se hace Respawn().

Si llega a 0 vidas, se reinicia el nivel y se pierden las monedas.

Respawn

PlayerControler: Guarda la posición inicial como punto de respawn. Cuando pierde una vida vuelve a esa posición y se resetea la velocidad del Rigidbody (para que no siga con impulso raro).

UI

UIUpdater: Está en el Canvas y tiene 2 TextMeshPro:

“Monedas: X”

“Vidas: X”
Se suscribe a los eventos del GameManager y actualiza los textos solo cuando cambian.
