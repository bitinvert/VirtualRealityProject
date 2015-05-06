# VirtualRealityProject

## Wichtig nachdem man das Projekt runtergeladen hat
Es muss wahrscheinlich noch eine Projekt Einstellung geändert werden.
Diese findet man unter:
- Edit -> Project Settings -> Editor
  - Version Controll = Visible Meta Files
  - Asset Serialisation = Force Text

## Das Projekt
- Grundidee: Ubongo, Tanagram

## Stufe 1
Es wird eine Grundfläche aus Quadraten vorgegeben, sowie mehrere verschiedene Grundformen.
Der Nutzer gibt die Grundformen auf, bewegt diese durch den Raum und platziert diese
so auf der Grundfläche, dass diese komplett ausgefüllt wird.

Bei dieser Stufe haben die Grundformen nur die Höhe 1. Sie müssen also hier noch nicht
aufeinander, sondern nur nebeneinander gestapelt/gelegt werden.
Damit das Setzen der Grundformen leichter fällt, wollen wir eine Art "Grid-Snap"
implementieren. Wenn die Fläche sich also in einem bestimmten Bereich befindet und
losgelassen wird, soll sie an einer festen Position liegen, also z.B. genau in den
quadratischen Flächen.

## Stufe 2
Als Erweiterung, wenn wir feststellen, dass die Stufe 1 zu wenig Arbeit für die
5CP darstellt, wollen wir die 1.Stufe auf höhere Höhen ausweiten, wobei die Grundformen
hierfür auch aufeinander gestapelt werden müssten.

## Weitere Ideen
- *Menüsteuerung*
  - *Timer/Stoppuhrfunktion:*
  Der Nutzer soll die Möglichkeit haben, die Zeit zu messen.
  - *Resetfunktion:*
  Im Falle von Problemen/Fehlern, soll der Nutzer alles in den Ausgangszustand
  zurück versetzen
  - *Prüfenfunktion:*
  Der Nutzer soll selbst angeben, ob er fertig und die Form prüfen möchte, um
  danach ggf. die nächste Grundfläche angezeigt zu bekommen.
