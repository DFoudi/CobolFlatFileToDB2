# CobolFlatFileToDB2
Outil .NET C# de parsing de fichiers plats COBOL et génération de scripts d’insertion SQL DB2, avec rapport d’anomalies. Projet démo pour secteur bancaire.

---

## 🏦 Contexte

Ce mini-projet simule un scénario très fréquent en banque : la migration ou l’intégration de données entre le legacy (COBOL/Mainframe, fichiers plats MVS) et un environnement moderne (DB2, .NET).

---

## ✨ Fonctionnalités

- **Parsing** d’un fichier plat COBOL (fixed-length)
- **Génération automatique de scripts SQL DB2** (`INSERT`)
- **Détection d’anomalies** : solde négatif, données manquantes
- **Export CSV** du rapport d’anomalies
- **Tests unitaires MSTest** sur chaque service métier
- **Architecture professionnelle** (dossiers Models, Services, Tests)

---

## 🗂️ Exemple de fichier plat (entrée)

0000012345DUPONT JEAN 00010200
0000012346MARTIN MARIE 00004500
0000012347SMITH JOHN -0001200
0000012348 SOPHIE 00005600

### **Layout COBOL simulé**
- N° Compte : 10 caractères
- Nom : 10 caractères
- Prénom : 10 caractères
- Solde : 8 caractères

---

## 🚀 Exemple d’exécution console

![capture](capture.png)

---

## 📁 Architecture du projet

CobolFlatFileToDB2/ # Projet principal (.NET Console)
├── Models/
│ └── CompteClient.cs
├── Services/
│ ├── CobolFileParser.cs
│ ├── Db2SqlGenerator.cs
│ └── AnomalyReportService.cs
│
CobolFlatFileToDB2.Tests/ # Projet de tests MSTest
├── CobolFileParserTests.cs
├── Db2SqlGeneratorTests.cs
└── AnomalyReportServiceTests.cs

---

## 🧪 Couverture par tests unitaires

- **CobolFileParserTests.cs** :  
  - Parsing normal, cas limites (lignes invalides)
- **Db2SqlGeneratorTests.cs** :  
  - Génération du script SQL DB2, vérification du format
- **AnomalyReportServiceTests.cs** :  
  - Détection d’anomalies (solde négatif, champs manquants)
  - Export CSV d’anomalies et vérification du contenu

---

## 📊 Pourquoi ce projet ?

- Illustrer la passerelle entre COBOL/Mainframe et .NET moderne
- Montrer de vraies problématiques “bancaires” (qualité de données, migration)
- Structure et pratiques professionnelles (architecture, tests, doc)

---

## 💡 Pour aller plus loin

- Conversion inverse : génération d’un fichier plat COBOL à partir de données .NET
- Interface graphique (WPF) pour la démonstration en banque
- Connexion réelle à une base DB2 (mockée ici)

---

## 📝 Auteur

David Foudi

---

## Licence

MIT
