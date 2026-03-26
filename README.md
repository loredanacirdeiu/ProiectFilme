# AplicatieFilmef
# 🎬 Movie Manager

Aplicație desktop dezvoltată în **C# (.NET)** pentru gestionarea unei colecții de filme.
Aplicația permite utilizatorului să adauge, editeze, șteargă și să caute filme într-o colecție locală printr-o interfață grafică simplă și intuitivă.

---

## 📌 Descriere

**Movie Manager** este o aplicație desktop care facilitează organizarea și administrarea informațiilor despre filme. Utilizatorul poate vizualiza lista filmelor, modifica datele acestora și efectua căutări rapide după diferite criterii.

Proiectul a fost realizat pentru a demonstra concepte precum:

* Programare orientată pe obiecte în **C#**
* Dezvoltarea aplicațiilor **desktop**
* Crearea unei **interfețe grafice**
* Gestionarea datelor într-o aplicație software

---

## 🚀 Funcționalități

✔️ Adăugarea unui film nou în colecție
✔️ Editarea informațiilor unui film existent
✔️ Ștergerea unui film din colecție
✔️ Căutarea filmelor după titlu, gen sau an
✔️ Afișarea filmelor într-un tabel
✔️ Validarea datelor introduse

---

## 🎥 Structura datelor

Fiecare film conține următoarele informații:

| Câmp       | Descriere                      |
| ---------- | ------------------------------ |
| ID         | Identificator unic al filmului |
| Titlu      | Numele filmului                |
| Gen        | Categoria filmului             |
| An lansare | Anul în care a fost lansat     |
| Durată     | Durata filmului în minute      |
| Regizor    | Numele regizorului             |
| Descriere  | Scurtă descriere a filmului    |

---

## 🖥️ Interfața aplicației

Aplicația include o fereastră principală care conține:

* tabel cu lista filmelor
* câmp de căutare
* opțiuni de filtrare
* butoane pentru gestionarea filmelor

### Acțiuni disponibile

* **Adaugă film**
* **Editează film**
* **Șterge film**
* **Caută film**

---

## 🗂️ Structura proiectului

Exemplu de clasă utilizată pentru modelul filmului:

```csharp
public class Film
{
    public int Id { get; set; }
    public string Titlu { get; set; }
    public string Gen { get; set; }
    public int AnLansare { get; set; }
    public int Durata { get; set; }
    public string Regizor { get; set; }
    public string Descriere { get; set; }
}
```

---

## 🛠️ Tehnologii utilizate

* **C#**
* **.NET**
* **Windows Forms / WPF**
* **Visual Studio**
* **OOP (Object-Oriented Programming)**

---

## ⚙️ Instalare și rulare

1. Clonează repository-ul:

```bash
git clone https://github.com/username/movie-manager.git
```

2. Deschide proiectul în **Visual Studio**

3. Rulează aplicația folosind:

```
Start / Run (F5)
```

---

## 📚 Scopul proiectului

Acest proiect a fost realizat în scop educațional pentru a exersa:

* dezvoltarea aplicațiilor desktop în **C#**
* implementarea unui **CRUD (Create, Read, Update, Delete)**
* organizarea unui proiect software
* utilizarea unei interfețe grafice pentru gestionarea datelor

---

## 📄 Licență

Acest proiect este realizat în scop educațional și poate fi utilizat liber pentru învățare și dezvoltare personală.



