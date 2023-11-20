__OBS this repocitory is fully in swedish__
# Projekt Unity 2D Spel - Quantum Coinmaster

![Quantum Coinmaster Logo](Logo_Studios.png)

## Översikt

Quantum Coinmaster är ett underhållande 2D-plattformsspel utvecklat i Unity, där spelaren samlar mynt för att avancera genom olika nivåer och klara spelet.

## Innehållsförteckning


- [Projekt Unity 2D Spel - Quantum Coinmaster](#projekt-unity-2d-spel---quantum-coinmaster)
  - [Översikt](#översikt)
  - [Innehållsförteckning](#innehållsförteckning)
  - [För att Spela spelet!](#för-att-spela-spelet)
    - [Bidra till projektet](#bidra-till-projektet)
    - [Gör ändringar och commita dem](#gör-ändringar-och-commita-dem)
  - [Designval](#designval)
    - [Gränssnitt och Användarvänlighet](#gränssnitt-och-användarvänlighet)
    - [Resursfördelning och Motivering](#resursfördelning-och-motivering)
  - [Tack till](#tack-till)
  - [Verktyg och källor](#verktyg-och-källor)
    - [Verktyg](#verktyg)
    - [Källor](#källor)
  - [Licens](#licens)
  - [Kontakt](#kontakt)

## För att Spela spelet!

Gå in på Teams, Simon om du har blivit inbjuden (Sofie och Per) till en grupp som heter Spel | Quantum Coinmaster.
Gå sedan till > För Lärare > Filer > ladda ner den senaste versionen av Version_Open Alpha.

Om du inte här tillgång till denna länk laddda ner filen från [Google drive](https://drive.google.com/file/d/1b7hWDymEQn4x6fOvgVfYycHfxm64M9vO/view?usp=sharing)

Det kan vara så att man måste unzipa filen. Sedan startar du spelet genom att öppna Quantum Coinmaster.exe! Enjoy!

### Bidra till projektet

För att kunna bidra tillprojektet måste man komma åt källkoden genom att klona vårat repocitoriet och skapa en egen branch från main om du vill bidra tillprojektet.

```bash
# Klona Repot
git clone https://github.com/ditt-användarnamn/quantum-coinmaster.git

# Skapa en egen Branch
cd quantum-coinmaster
git checkout -b din-egen-branch

```

Öpna sedan projektet i en valfri kodrediskerare, samt i unity för att att se grafik och testa spelet.

### Gör ändringar och commita dem

```bash
git add .
git commit -m "Beskrivning av dina ändringar"

# Pusha din branch till GitHub
git push origin din-egen-branch

# Öppna en pull request på GitHub för att föreslå ändringarna

```

## Designval

### Gränssnitt och Användarvänlighet



Spelet har ett intuitivt gränssnitt och fokus på användarvänlighet för att ge spelaren en engagerande upplevelse:

- **Tydligt gränssnitt**: Enkelt och tydligt gränssnitt som ger spelaren nödvändig information utan att överbelasta skärmen.

- **Anpassningsbarhet**: Möjlighet för spelaren att anpassa kontroller och inställningar för en personlig spelupplevelse.

- **Progressionssystem**: Tydlig indikation av framsteg och prestationer för att motivera spelaren.

### Resursfördelning och Motivering

Vi har noggrant övervägt resursfördelningen och vidtagit åtgärder för att optimera spelets prestanda:

- **Texturer och Grafik**: Användning av komprimerade texturer och effektiva grafiska resurser för att minimera filstorleken och laddningstider.

- **Kodoptimering**: Strukturerad och optimerad kod för att säkerställa en smidig körning och minimera minnesanvändning.

- **Ljudresurser**: Effektiv användning av ljudresurser för att balansera ljudkvalitet och filstorlek.

## Tack till

Vi vill tacka alla som har bidragit till Quantum Coinmaster-projektet. Deras engagemang och insatser har varit avgörande för projektets framgång.



- ### Simon Meier -  [abbsimmei](https://github.com/abbsimmei)

  - __Projektledare__
  - __Level Design__
    - Egypt Scene
    - Pyramid Scene
    - Moon Scene 1,2
    - Cyberpunk Scene
    - Outro Cutscene
  - sprite design 
  - Tilemaps Design
  - Rörelse av karaktären
  - Camera movement
  - "Death and respawn"
  - Bugfixd


- ### Viggo Haimanas Bygden [abbvighai](https://github.com/abbvighai)
  - __Ansvariga för Grafisk design__
    - Sprites
    - TileMaps
  - __TileMap__
  - level design
    - __Tutorial__
    - Edwardiant scene
    - Intro Cutscene
  - Animering
  - Dialoger
  - BugFix
- ### Sebastian Alin [sebastian200](https://github.com/sebastian200)
  - __Ansvarig för kod och spelmekanik__
  - __GUI design__
    - Menu
    - Main Menu
    - Death Screan
  - Coin Collection
  - PowerUps
  - Save And loading
  - __Sound Designer__
    - Musik
    - AmbientSounds
    - SFX
    - Inspelning av ljud
  - Bugfix
 
## Verktyg och källor

Vi har använt följande verktyg och källor i utvecklingen av Quantum Coinmaster:

### Verktyg

1. [**Unity Game Engine**](https://unity.com/) - Unity har varit kärnan i vårt projekt att skapa vårt spel
2. [**Github**](https://github.com/abbindustrigymnasium/2d-spel-i-unity-grupp-sebastian) - Platform rediskera och dela samma kod på olka datorer
3. [**Pain.NET**](https://www.getpaint.net/) - Design av sprites och Tilemap
4. [**Audacity**](https://www.audacityteam.org/) - Inspelning av ljud

### Källor

1.  [__Chat GPT__](https://chat.openai.com/c/1f4196ea-ee94-4880-be12-9dea5411ec90 ) - Använt flr Prototyper av kod, till hjälp med byggfixing
  2. [__Pixaaby__](https://pixabay.com/sound-effects/search/freesounds/) källa för ljud och SFX
3. [__bing immage creator__](https://www.bing.com/create) Bilder som refernsmatial
4. [__Youtube__](https://youtube.com/) Tutorial Videor till projektet (se alla videor Här:)
   - [The Unity Tutorial For Complete Beginners](https://www.youtube.com/watch?v=XtQMytORBmM&t=700s)
   - [Grunderna till c# spellista](https://www.youtube.com/watch?v=N775KsWQVkw&list=PLPV2KyIb3jR4CtEelGPsmPzlvP7ISPYzR)
   - [Grunderna av unity Spellista](https://www.youtube.com/watch?v=on9nwbZngyw&list=PLPV2KyIb3jR6TFcFuzI2bB7TMNIIBpKMQ)
     - Player Movement, video 2
     - Camera Movement, video 4
     - 2D Animation, video 3
   - [Grunderna av unity Spellista (av en annan skapare)](https://www.youtube.com/watch?v=Ii-scMenaOQ&list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U)
     - Tilemap & Tile Palette, video 2
     - Animation, video 4
     - Grounding Check Using Boxcast, video 6
     - Player Death Logic, video 8
     - Moving platforms, video 9
   - [2D COIN COLLECTING IN UNITY! ](https://www.youtube.com/watch?v=YUp-kl06RUM)
   - [How to make a Dialogue System in Unity](https://www.youtube.com/watch?v=_nRzoTzeyxU)
   - [SAVE & LOAD SYSTEM in Unity](https://www.youtube.com/watch?v=XOjd_qU2Ido&t=2s)
   - [Unity UI Tutorial](https://www.youtube.com/watch?v=IuuKUaZQiSU)
   - [START MENU in Unity](https://www.youtube.com/watch?v=zc8ac_qUXQY)
   - [SETTINGS MENU in Unity](https://www.youtube.com/watch?v=YOaYQrN1oYQ)
   - [Introduction to AUDIO in Unity](https://www.youtube.com/watch?v=6OT43pvUyfY)
   - [Easy Tilemaps and Dynamic Auto Tiling - Unity 2D](https://www.youtube.com/watch?v=8UctaO5DwUE)
   - [2D Platformer Movement With Unity's New Input System](https://www.youtube.com/watch?v=24-BkpFSZuI)
   - [How to make a 2D Slide](https://www.youtube.com/watch?v=vqdSfMxbdPc)
   - [Idle, Run and Jump Animations](https://www.youtube.com/watch?v=Sg_w8hIbp4Y)

## Licens
Denna projekt och dess kod släpps under en öppen källkodslicens, vilket ger alla friheten att använda, ändra och dela innehållet och koden fritt.

## Kontakt
kontakta oss visa teams