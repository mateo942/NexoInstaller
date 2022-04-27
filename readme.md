# Nexo Installer

Narzêdzie umo¿liwiaj¹ce w ³atwy sposób pakowanie rozwi¹zañ w³asnych dla programu InsERT Nexo

### Wymagania

Aby uruchomiæ narzêdzie potrzebujesz:

* .Net Framework 4.7.1
* InsERT Nexo (https://www.insert.com.pl/programy_dla_firm/insert_nexo/nexo_pro.html)
* Nexo SDK


## U¿ycie

### Pakowanie rozwi¹zania w³asnego

```
.\Nexo.Installer.exe pack -s "C:\rozwiazania\10" -v "1.0.0.7" -n "Mateusz Rozwianie"
```

Wszystkie pliki znajduj¹ce siê w folderze `C:\rozwiazania\10` zostan¹ spakowane do pliku `?.mpkg`
Jeœli w folderze znajduje siê manifest `source.manifest.xml` zostanie on wykorzystany, w przeciwnym wypadku narzêdzie utworzy swój.

> Spacje w nazwie rozwi¹zania s¹ zamieniane na `_`

### Wysy³anie rozwi¹zania w³asnego

```
.\Nexo.Installer.exe upload -c "Server=DESKTOP-TEST;Database=InsERT_Launcher;User Id=sa;Password=super-password;" -s "C:\rozwiazania\10\Mateusz_Rozwianie-1.0.0.7.mpkg"
```

Spakowane rozwi¹zanie w³asne zostanie przes³¹ne i wgrane do bazy danych `InsERT_Launcher`

### Instalowanie rozwi¹zania w³asnego

```
.\Nexo.Installer.exe install -c "Server=DESKTOP-TEST;Database=Nexo_Demo;User Id=sa;Password=super-password;" -s "C:\rozwiazania\10\Mateusz_Rozwianie-1.0.0.7.mpkg" -r true
```

Rozwi¹zanie w³asne dostanie dodane do wybranego przez nas podmiotu (`Nexo_Demo`).
W przypadku kiedy mamy ju¿ zainstalowane starsze rozwi¹zanie nale¿y u¿yæ opcji `-r` aby je usun¹æ z podmiotu.
Jeœli rozwi¹zanie w³asne w tej samej wersji jest ju¿ zainstalowane, rozwi¹zanie nie zostanie zaktualizowane.

### Czyszczenie rozwi¹zañ w³asnych

```
.\Nexo.Installer.exe cleanup -c "Server=DESKTOP-TEST;Database=InsERT_Launcher;User Id=sa;Password=super-password;" -n "Mateusz_Test"
```

Usuwamy wys³ane rozwi¹zania z bazy `InsERT_Launcher` wed³ug nazwy `Mateusz_Test`.
Domyœlnie zostawiamy *5* ostatnich. Aby znieniæ tê wartoœæ nale¿y u¿yæ opcji `-m`