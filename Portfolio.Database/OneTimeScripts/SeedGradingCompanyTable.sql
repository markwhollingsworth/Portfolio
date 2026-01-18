DELETE FROM [dbo].[GradingCompany]

INSERT INTO [dbo].[GradingCompany]([Id], [Description], [Abbreviation])
VALUES (1, 'Professional Coin Grading Service', 'PCGS'),
       (2, 'Numismatic Guaranty Company', 'NGC'),
       (3, 'American Numismatic Association Certification Service', 'ANACS'),
       (4, 'Certified Acceptance Corporation', 'CAC')
