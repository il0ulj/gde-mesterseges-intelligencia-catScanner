# GDE
## Mesters�ges intelligencia tant�rgy
### catScanner beadand� feladat le�r�sa

Yolov5-ben k�sz�tsenek egy onnx modell-t pythonban (jupiter vagy visual studio), mely minimum 1 kateg�ri�t tartalmaz. A dataset-et �n�k c�mk�zz�k fel hozz�. K�sz�tsenek egy .Net alkalmaz�st (Windows form vagy Blazor), mely a kamer�r�l k�sz�tett vagy egy felt�lt�tt k�pet elemez az onnx modell-t haszn�lva. .Net alkalmaz�sban a grafikus megjelen�t�ssel keretezz�k be az objektumot, �s �rj�k ki a label-t (mit tal�lt), valamint a predikci�t (mekkora val�sz�n�s�ggel ismerte fel az c�mk�j� objektumot a modell).
T�m�r�tett f�jlk�nt k�ldj�k el, mely �llom�ny az al�bbiakat tartalmazza:
- dataset (k�pek, c�mk�z�s adatai, stb, train, validation �s test mappa is)
- python k�d, amelyben a tr�ninget k�sz�tett�k
- onnx f�jl
- .Net alkalmaz�s
