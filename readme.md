# Nexo Installer

Narz�dzie umo�liwiaj�ce w �atwy spos�b pakowanie rozwi�za� w�asnych dla programu InsERT Nexo

### Wymagania

Aby uruchomi� narz�dzie potrzebujesz:

* .Net Framework 4.7.1
* InsERT Nexo (https://www.insert.com.pl/programy_dla_firm/insert_nexo/nexo_pro.html)
* Nexo SDK


## U�ycie

### Pakowanie rozwi�zania w�asnego

```
.\Nexo.Installer.exe pack -s "C:\rozwiazania\10" -v "1.0.0.7" -n "Mateusz Rozwianie"
```

Wszystkie pliki znajduj�ce si� w folderze `C:\rozwiazania\10` zostan� spakowane do pliku `?.mpkg`
Je�li w folderze znajduje si� manifest `source.manifest.xml` zostanie on wykorzystany, w przeciwnym wypadku narz�dzie utworzy sw�j.

> Spacje w nazwie rozwi�zania s� zamieniane na `_`

### Wysy�anie rozwi�zania w�asnego

```
.\Nexo.Installer.exe upload -c "Server=DESKTOP-TEST;Database=InsERT_Launcher;User Id=sa;Password=super-password;" -s "C:\rozwiazania\10\Mateusz_Rozwianie-1.0.0.7.mpkg"
```

Spakowane rozwi�zanie w�asne zostanie przes��ne i wgrane do bazy danych `InsERT_Launcher`

### Instalowanie rozwi�zania w�asnego

```
.\Nexo.Installer.exe install -c "Server=DESKTOP-TEST;Database=Nexo_Demo;User Id=sa;Password=super-password;" -s "C:\rozwiazania\10\Mateusz_Rozwianie-1.0.0.7.mpkg" -r true
```

Rozwi�zanie w�asne dostanie dodane do wybranego przez nas podmiotu (`Nexo_Demo`).
W przypadku kiedy mamy ju� zainstalowane starsze rozwi�zanie nale�y u�y� opcji `-r` aby je usun�� z podmiotu.
Je�li rozwi�zanie w�asne w tej samej wersji jest ju� zainstalowane, rozwi�zanie nie zostanie zaktualizowane.

### Czyszczenie rozwi�za� w�asnych

```
.\Nexo.Installer.exe cleanup -c "Server=DESKTOP-TEST;Database=InsERT_Launcher;User Id=sa;Password=super-password;" -n "Mateusz_Test"
```

Usuwamy wys�ane rozwi�zania z bazy `InsERT_Launcher` wed�ug nazwy `Mateusz_Test`.
Domy�lnie zostawiamy *5* ostatnich. Aby znieni� t� warto�� nale�y u�y� opcji `-m`