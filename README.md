# Practica1JorgeGarciaSanz
Primera practica de la asignatura

PlayerControler: Básicamente lee las teclas (flechas/WASD) para mover al personaje por el suelo (en XZ). Para el salto usa el Rigidbody: cuando pulsas Space, primero comprueba si estás tocando el suelo (isGrounded, que se actualiza con colisiones con objetos tag Ground) y solo entonces te deja saltar, así no puedes spamear saltos en el aire. Y si activas lo del doble salto, te deja pegar un segundo salto en el aire una única vez.

FallingPlatform: Esta plataforma “se activa” cuando el jugador se sube encima (y no si le das de lado). Cuando detecta que el Player está arriba, empieza una cuenta atrás con Time.time y esa cuenta sigue aunque te bajes. Al terminar, la plataforma baja a una velocidad fija hasta una altura mínima (minY), se queda un momento parada y luego vuelve a su posición inicial, dejándolo todo reseteado para que funcione otra vez igual.

MovingPlantform: Aquí la plataforma va y vuelve entre dos puntos: su posición inicial y la posición de un objeto destino que usas como marcador (y que se hace invisible). En FixedUpdate se mueve con MoveTowards a velocidad constante y cuando llega “casi” al destino cambia el sentido para volver, y así en bucle. Se mueve con rb.MovePosition porque es lo más decente para mover cosas con Rigidbody sin que la física se vuelva loca.
