namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    #region Enumerations

    public enum TypeFG : short
    {
        Facturable = 0,
        Caisse = 1
    }
    public enum TypeUserTablette : short
    {
        Commercial = 0,
        Client = 1
    }
    public enum InterrogationCA : short
    {
        Tous = 0,
        En_Confidentialite = 1
    }

    public enum ValidateAppel : short
    {
        Saisie = 0,
        Planifier = 1,
        Valide = 2,
        Annuler = 3
    }

    public enum TypeDocumentDI : short
    {
        Aucun = 0,
        PC = 11,
        BC = 12,
        BL = 13,
        FC = 16
    }

    public enum StatusEntete : short
    {
        Saisi = 0,
        Confirmer = 1,
        Accepter = 2
    }

    public enum TypeValidation  
    {
        Non_Valide = 0,
        Partiellement_Valide = 1,
        Valide = 2
    }

    public enum TypeGamme
    {
        Gamme = 0,
        EnumGammme = 1
    }

    public enum TypeUniteTemps : short
    {
        Aucun = 0,
        Heure = 1,
        Minute = 2,
        Jour = 3
    }

    public enum TypeFabrication : short
    {
        Demande_Besoin = 0,
        Demande_Fabrication = 1,
        Bon_Fabrication = 2
    }
    public enum TypeCheque
    {
        Imprimer = 0,
        Consommer = 1,
        Reserver = 2
    }
    public enum TypeControleStock : int
    {
        Reel = 0,
        Reel_MoisReserver = 1,
        Reel_PlusCommander = 2,
        Reel_PlusCommander_MoisReserver = 3
    }
    public enum Typetransact : short
    {
        Insert = 0,
        Update = 1,
        Delete = 2,
        UpdArtStock = 3
    }

    public enum TypePV
    {
        PV = 0,
        Central = 1,
        Annexe = 2
    }

    public enum TypeCmdFabrication : int
    {
        Stock_Interne = 0,
        Commande = 1
    }

    public enum TypeNomenclature : short
    {
        Aucun = 0,
        Fabrication = 1,
        ArticleLiee = 2,
        Dimension = 3
    }

    public enum EtatFabrication : short
    {
        Commencer = 0,
        Terminer = 1
    }

    public enum TypeRistourne : short
    {
        Montant = 0,
        Pourcentage = 1
    }

    public enum EtatSolde : short
    {
        Tous = 0,
        Client_Solde = 1,
        Client_Crediteur = 2,
        Client_Debiteur = 3
    }

    public enum Civilite : short
    {
        M = 0,
        Mme = 1,
        Mlle = 2
    }

    public enum OrigEqRemp : short
    {
        Origine = 0,
        Equivalente = 1,
        Remplacement = 2
    }

    public enum PVMinParapportRemise : short
    {
        Avant_Remise = 0,
        Apres_Remise = 1
    }

    public enum TypeTacheGDI : short
    {
        Aucun = 0,
        Heritage = 1,
        Creation = 2,
        Transformation = 3,
        Creation_Transformation = 4
    }

    public enum TypeDocumentGDI : short
    {
        Aucun = 0,
        PC = 11,
        BC = 12,
        BL = 13,
        FC = 16
    }

    public enum DomaineEngagement : short
    {
        Commercial = 0,
        Financier = 1
    }

    public enum TypeRessource : short
    {
        Aucun = -2,
        Personnel = 0,
        Materiel = 1,
        Machine = 2,
        Vehicule = 3
    }
	
	  public enum ProtectPiece
    {
        Aucun = 0,
        Tout_Autoriser = 1,
        Masquer = 2,
        Verrouiller = 3,
        Disponible = 4,
        Tout_Interdit = 5
    }

    public enum AutorisationPiece
    {
        Reference = 2,
        Cours = 3,
        Affaire = 4,
        RepresentantEntete = 5,
        DepotEntete = 6,
        Devise = 7,
        Valider_Piece = 12,
        Imprimer_Piece = 13,
        Regler_Piece = 14,
        Detail_Reglement = 15,
        Comptabiliser = 16,
        Creer_Piece = 17,
        Supprimer_Piece = 18,
        Transformer_Piece = 19,
        Prix_Unitaire = 22,
        Remise = 23,
        FraisLigne = 24,
        Unite = 25,
        RepresentantLigne = 26,
        DepotLigne = 27,
        PUTTC = 28,
        CMUP = 31,
        Cout_Revient = 32,
        Marge_Unitaire = 33,
        Montant_Marge = 34,
        Information_Libre = 41,
        FraisEntete = 42,
        Information_Livraison = 43,
        Cours_Devise = 51,
        PU_Devise = 52,
        Qte_Unite = 53,
        Designation = 54,
        Type_Remise = 55,
        Frais_Unitaire = 56,
        Qte_Mvt = 57,
        Mnt_HT_Brut = 61,
        Remise_Unitaire = 62,
        Mnt_Remise = 63,
        Mnt_HT_Net = 64,
        Mnt_TTC = 65,
        Mnt_HT_Devise = 66,
        Mnt_TTC_Devise = 67,
        Mnt_Remise_Devise = 68,
        TVA_Unitaire = 71,
        Mnt_TVA = 72,
        Mnt_Taxe = 73,
        Mnt_Cout = 74,
        AffaireLigne = 75,
        QteTransf = 76,
        QteRetourner = 77,
        QteLivrer = 78,
        PUNetHT = 79,
        PUNetDevise = 80,
        Ristourne = 120
    }

    public enum ComposantRessources
    {
        Composant = 0,
        Ressources = 1,
        MatierePremiere = 2,
        Dechet = 3,
        ProduitFini = 4
    }


    public enum TypeQteArticle
    {
        Variable = 0,
        Non_Variable = 1
    }

    public enum IdTableInfoLibre
    {
        EntetePiece = 1,
        LignePiece = 2,
        Famille = 3,
        Article = 4,
        Tiers = 5
    }

    public enum TypeArticle
    {
        Standard = 0,
        Generique = 1,
        Marcher = 2,
        Consommable = 3,
        Ressources = 4,
        Gamme=5
    }

    public enum TypeTransformationPiece
    {
        Generale = 1,
        Retour = 2,
        Livraison = 3,
        Solde = 4,
        SAV =5
    }

    public enum TypeCodeConfidentialite : int
    {
        Client = 0,
        Fournisseur = 1,
        Article = 2
    }

    public enum SigneChiffreAffaire : int
    {
        //AucunSigne = -1,
        //SignePlus = 0,
        //SigneMois = 1

        AucunSigne = 0,
        SignePlus = 1,
        SigneMois = -1
    }

    public enum TypeChamps : int
    {
        Entier = 1,
        Chaine = 2,
        Date = 3,
        Groupe = 4
    }

    public enum TypeSelection : int
    {
        Valeur = 1,
        Intervalle = 2
    }

    public enum EtatReglement
    {
        Sans_Reglement = 0,
        Partillement_Regler = 1,
        Totalement_Regler = 2
    }

    public enum EtatInventaire
    {
        Non_Valide = 0,
        Validation_Partielle = 1,
        Validation_Total = 2
    }

    public enum TypeMarge
    {
        En_Fonction_CMUP = 0,
        En_Fonction_Ventilation = 1
    }

    public enum ActionStock
    {
        Aucun = 0,
        Diminuer = 1,
        Alimenter = 2
    }

    public enum TypeColonne
    {
        ColonnePiece = 0,
        ColonneRechercheArticle = 1
    }

    public enum IdColonne
    {
        RefArticle = 1,
        DesignArticle = 2,
        PrixUnitaire = 3,        
        Unite = 4,
        QteUnite = 5,
        QteMvt = 6,
        Remise = 7,
        PrixHTNet = 8,
        PrixUTTC = 9,
        MontantHT = 10,
        MontantTTC = 11,
        Depot = 12,
        Taxes = 13,
        TotalNetHT = 14,
        TotalTTC = 15,
        TotalNetApayer = 16,
        TotalRemise = 17,
        TotalQte = 18,
        TotalTaxes = 19,
        TotalTPHT = 20,
        TotalTPTTC = 21,
        TotalTVA = 22,
        MontantRemise = 23,
        RemiseUnitaire = 24,
        MontantHTBrut = 25,
        TVAUnitaire = 26,
        MontantTVA = 27,
        MontantTaxe = 28,
        MontantCout = 29,
        FraisUnitaire = 30,
        MargeUnitaire = 31,
        Frais = 32,
        CMUP = 33,
        PrixRevient = 34,
        MontantMarge = 35,
        QteTransformer = 36,
        QteRetournee = 37,
        QteLivree = 38,
        MontantHTDevise = 39,
        MontantTTCDevise = 40,
        MontantRemiseDevise = 41,
        PrixUnitaireNetDevise = 42,
        PrixUnitaireDevise = 43,
        TotalDevise = 44, 
        CoursDevise = 45,
        Representant = 46,
        Affaire = 47,
        QteGratuite = 48,
        Ressources = 49,
        UniteEmbalage = 50,
        QteEmbalage = 51,
        QteNonEmbaler = 52,
        Modele_Gratuite = 53,
        RefArticleRA = 54,
        DesignArticleRA = 55,
        CodeFamilleRA = 56,
        QteStockRA = 57,
        PrixUAchatHTRA = 58,
        PrixUVenteHTRA = 59,
        TauxTVARA = 60,
        PrixUAchatTTCRA = 61,
        PrixUVenteTTCRA = 62,
        CMUPRA = 63,
        Longueur = 64,
        Largeur = 65,
        Epaisseur = 66,
        NombrePiece = 67,
        Reference_Fournisseur = 68,
        QteFacturer = 69
    }

    public enum IdColonneUser
    {
        RefArticle = 1,
        DesignArticle = 2,
        QteSto = 3,
        QteCom = 4,
        QteRS = 5,
        QtePR = 6,
        PAchat = 7,
        TMarge = 8,
        PVenteHT = 9,
        TTVA = 10,
        PVenteTTC = 11
    }

    public enum NatureTiers
    {
        Interne = 0,
        Externe = 1
    }

    public enum EtatEpuise
    {
        NonEpuise = 0,
        PartEpuise = 1,
        Epuise = 2
    }

    public enum Perimee
    {
        NonPerime = 0,
        PartPerime = 1,
        Perime = 2 
    }

    public enum TypePrix
    {
        PrixVente = 0,
        PrixAchat = 1,
        CMUP = 2
    }

    public enum TypeStructure
    {
        Type_Operation = 1,
        Type_Piece = 2,
        Annee = 3,
        Mois = 4,
        Compteur = 5
    }

    public enum TypeEnregistrement
    {
        Aucun = 3,
        Entete = 0,
        Ligne = 1,
        Reglement = 2
    }
    public enum TypeFA
    {
        Detail = 0,
        Total = 1,
        Centraliseur = 2
    }
    public enum CategoriePiece
    {
        Document = 0,
        ReglementClient = 1,
        ImpayeClient = 2,
        Bordereau = 3,
        BRFactoring = 4,
        ReglementFournisseur = 6,
        ImpayeFournisseur = 7,
        Marche = 8,
        PieceAchat = 9,
        PieceVente = 10
    }

    public enum TypeMontantNGP
    {
        Montant = 0,
        Formule = 1
    }

    public enum TypeStock
    {
        Aucun = 0,
        Stock_Reel = 1,
        Stock_Reserver = 2,
        Stock_Commander = 3,
        Stock_Preparer = 4,
        Stock_Importer = 5  
    }

    public enum TypeTag
    {
        Entier = 1,
        Domaine = 2,
        TypeDomaine = 3,
        TypePiece = 4
    }

    public enum TypePesage
    {
        Livraison_Fitoulina = 0,
        Reception_Fitoulina = 1,
        Livraison_Raffinerie = 2,
        Reception_Raffinerie = 3,
        Livraison_Savolive = 4,
        Reception_Savolive = 5,
        Livraison_Savonnerie = 6,
        Reception_Savonnerie = 7,
        Entree_Raffinerie = 8,
        Sortie_Raffinerie = 9
    }

    public enum ModeRubrique
    {
        Par_Annee = 0,
        Par_Mois = 1
    }
    public enum Mode
    {
        Ajouter = 0,
        Modifier = 1,
        Supprimer =2

    }
    public enum TypeTransformation
    {
        Document_En_Document = 0,
        Tous_En_Document = 1
        
    }

    public enum Domaine_Formule
    {
        Operateur = 0,
        Parenthese = 1,
        Champ = 2,
        Nombre = 3
    }

    public enum TypeFormule
    {
        Montant = 0,
        Pourcentage = 1,
        Formule = 2
    }

    public enum Type_Formule
    {
        Nombre = 0,
        Qte_Stock = 3,
        Qte_Mini = 4,
        Qte_Preparer = 5,
        Qte_Commander = 6,
        Qte_Vendue = 7,
        Qte_Commander_Vente = 8,
        Qte_Proposer_Achat = 9,
        Addition = 11,
        Soustraction = 21,
        Multiplication = 31,
        Devision = 41,
        Puissance = 51,
        Ouvrante = 12,
        Fermante = 22   

    }

    public enum SensTaxeGC
    {
        Deductible = 0,
        Collecte = 1
    }

    public enum TypeTauxGC
    {
        Taux = 0,
        Montant = 1,
        Quantite = 2
    }

    public enum TypeFormuleCalculFrais
    {
        Nombre = 0,
        Mtn_Devise_Total = 3,
        Mtn_Devise = 4,
        Cours_Douane = 5,
        Cours_Dossier = 6,
        Taux_Frais = 7,
        Mtn_Prorata = 8,
        Formule = 9,
        Resultat_Frais = 13,
        Addition = 11,
        Soustraction = 21,
        Multiplication = 31,
        Devision = 41,
        Puissance = 51,
        Ouvrante = 12,
        Fermante = 22

    }

    public enum TypeTraitement  
    {
        CA = 0,
        Qte = 1
    }

    public enum TypeFacture : short
    {
        Facture = 0,
        Retour = 1,
        Avoir = 2
    }

    public enum UserDroit
    {
        Utilsateur = 0,
        Administrateur = 1
    }

    public enum UniteAchat
    {
        Piéce = 0,
        Douzaine = 1,
        Ecrin_De_6 = 2,
        Unité = 3,
        Heure = 4,
        Jour = 5,
        Demi_Journée = 6,
        kms = 7
    }

    public enum NatureCompteGenerale
    { 
       Aucune = 0,
       Client = 1,
       Fournisseur = 2,
       Salarié = 3,
       Banque = 4,
       Caisse = 5,
       Amortissement_Provision = 6,
       Résultat_bilan = 7,
       charge = 8,
       Produit = 9,
       Résultat_Gestion = 10,
       Immobilisation = 11,
       Capitaux = 12,
       Stock = 13,
       Titre = 14
    }

    public enum Cotation
    {
        Certain = 0,
        Incertain = 1
    }

    public enum ChoixRemise
    { 
        Manuel = 0,
        Article = 1,
        Famille = 2,
        Fournisseur = 3,
        Cumule = 4,
        Cascade = 5
    }

    public enum ArticleType
    {
        Standard = 0,
        Gamme = 1,
        RessourceUnit = 2,
        RessourceMult = 3
    }

    public enum EtatDossier
    {
        Creation = 0,
        En_Cours = 1,
        Cloturer = 2
    }

    public enum UniteDeVente
    {
        Piéce = 0,
        Douzaine = 1,
        Ecrin_De_6 = 2,
        Unité = 3,
        Heure = 4,
        Jour = 5,
        Demi_Journée = 6,
        kms = 7
    }


    /// <summary>
    /// 
    /// </summary>


    public enum EtatCloture : short
    {
        NonCloture = 0,
        Cloture = 1
    }

    public enum TypeMvtCaisse : short
    {
        Fonds = 0,
        Recette = 1,
        Depense = 2
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Etat
    {
        New,
        Loaded,
        Deleted,
        Fictive
    }

    /// <summary>
    /// 
    /// </summary>
    public enum LockType : short
    {
        Modification = 3,
        Read = 4
    }

    /// <summary>
    /// 
    /// </summary>
    public enum NotificationType : short
    {
        Ajout = 4,
        Suppression = 6
    }

    /// <summary>
    /// 
    /// </summary>
    //public enum SensTaxe
    //{
    //    Deductible = 0,
    //    Collecte = 1
    //}

    /// <summary>
    /// 
    /// </summary>
    public enum SuiviStock : short
    {
        Aucun = 0,
        Serialise = 1,
        CMUP = 2,
        FIFO = 3,
        LIFO = 4,
        Lot = 5
    }

    public enum TarifCalcul
    {
        Global = 1,
        Tranche = 0
    }

    public enum TarifObjectif
    {
        Montant = 1,
        Quantite = 0
    }

    public enum TarifType
    {
        Commision = 0,
        Rabais = 1,
        Promotion = 2
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TypeCatCompta : short
    {
        Vente = 0,
        Achat = 1,
        Stock = 2
    }

    /// <summary>
    /// 
    /// </summary>

    /// <summary>
    /// 
    /// </summary>
    public enum TypeEmplacement : short
    {
        Standard = 0,
        Transit = 1,
        Controle = 2
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TypeFile
    {
        F_COMPTET,
        F_ARTICLE,
        F_DOCENTETE,
        F_DOCLIGNE
    }

    /// <summary>
    /// 
    /// </summary>

    /// <summary>
    /// 
    /// </summary>
    //public enum TypeTaux
    //{
    //    Taux = 0,
    //    Montant = 1,
    //    Quantite = 2
    //}

    /// <summary>
    /// 
    /// </summary>
    //public enum TypeTaxe
    //{
    //    TVADebit = 0,
    //    TVAEncaissement = 1,
    //    TPHT = 2,
    //    TPTTC = 3,
    //    TPPoids = 4,
    //    TVACEE = 5,
    //    Surtaxe = 6
    //}

    /// <summary>
    /// 
    /// </summary>
    public enum TypeValeur
    {
        Text = 9,
        Montant = 20,
        Table = 22,
        Date = 3,
        DateLongue = 14,
        Valeur = 7
    }

 public enum TypeRemise : short
    {
        Montant = 0,
        Pourcentage = 1,
        Quantité = 2
    }
    //public enum TypeRemise : short
    //{
    //    Montant = 0,
    //    Pourcentage = 1,
    //    Quantité = 2
    //}

    public enum CreateOrImportOrTransf : short
    {
        Creation = 0,
        Importation = 1,
        Transformation = 2
    }

    //public enum TypeDocument : short
    //{
    //    Aucun = 0,
    //    PC = 11,
    //    BC = 12,
    //    BL = 13,
    //    FC = 16
    //}

    public enum TypeReglement : short
    {
        Acompte = 0,
        Bon_Achat = 1,
        Règlement = 2
    }


    public enum TypeTache : short
    {
        Aucun = 0,
        Heritage = 1,
        Creation = 2,
        Transformation = 3,
        Creation_Transformation = 4
    }

    public enum Nomenclature : short
    {
        Aucun = 0,
        Fabrication = 1,
        Commerciale_Composé = 2,
        Commerciale_Composant = 3,
        Article_Lié = 4
    }

    //public enum Domaine : short
    //{
    //    Vente = 0,
    //    Achat = 1,
    //    Stock = 2,
    //    Ticket = 3,
    //    DocumentInterne = 4
    //}

    public enum TypeDroit
    {

        Lire = 3,
        Ecriture = 2,
        Suppression = 1
    }

    #endregion Enumerations
}