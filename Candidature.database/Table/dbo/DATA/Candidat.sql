CREATE TABLE [dbo].[Candidat]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY , 
    [Nom] NVARCHAR(MAX) NULL, 
    [Prenom] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL, 
    [Telephone] NVARCHAR(MAX) NULL, 
    [NbrAnneesDexperience] NVARCHAR(MAX) NULL, 
    [DernierEmployeur] NVARCHAR(MAX) NULL, 
    [File] VARBINARY(MAX) NULL, 
    [Path] NVARCHAR(MAX) NULL, 
    [REF_NiveauEtude_Id] INT NULL, 
    
   
    CONSTRAINT [FK_Candidat_ToREF_NiveauEtude] FOREIGN KEY ([REF_NiveauEtude_Id]) REFERENCES [REF_NiveauEtude]([Id])
)
