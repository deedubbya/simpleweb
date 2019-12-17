/* Accounts */
INSERT INTO Account (aStatus, aCompanyName) 
	VALUES ('ACTIVE', 'COMPANY 1'); 

/* Users */
INSERT INTO [User] (uStatus, uFirstName, uLastName, uEmailAddress, uPassword) 
	VALUES ('ACTIVE', 'Doug', 'Dong', 'ddong@gmail.com', 'storeWinter343');
INSERT INTO [User] (uStatus, uFirstName, uLastName, uEmailAddress, uPassword) 
	VALUES ('ACTIVE', 'Steve', 'Williams', 'swilliams@hotmail.com', 'videoTruck682');
INSERT INTO [User] (uStatus, uFirstName, uLastName, uEmailAddress, uPassword) 
	VALUES ('INACTIVE', 'Roy', 'Woo', 'rwoo@amazon.com', 'televisionFreezer827');

/* Menus */
INSERT INTO Menu (mName) 
	VALUES ('Main Menu');
INSERT INTO MenuNavigationItem (mniMenuID, mniMenuHierarchy, mniMenuSort, mniLinkType, mniPageID, mniExternalLink, mniTitle)
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'HOME'
UNION ALL
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'ABOUT' 
UNION ALL
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'PRODUCTS'
UNION ALL
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'CONTACT'

INSERT INTO Menu (mName) 
	VALUES ('Footer Menu');
INSERT INTO MenuNavigationItem (mniMenuID, mniMenuHierarchy, mniMenuSort, mniLinkType, mniPageID, mniExternalLink, mniTitle)
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'HOME'
UNION ALL
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'ABOUT' 
UNION ALL
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'PRODUCTS'
UNION ALL
SELECT @@IDENTITY, 0, 0, 'PAGE', null, null, 'CONTACT'
UNION ALL
SELECT @@IDENTITY, 0, 0, 'EXTERNAL', null, null, 'LEGAL'

INSERT INTO Menu (mName) 
	VALUES ('About Menu');

/* Pages */
INSERT INTO [Page] (pStatus, pIsHomePage, pVisibility, pHeaderTitle, pHtmlContent)
	VALUES ('ACTIVE', 0, 'Visible', 'HOME', '');
INSERT INTO [Page] (pStatus, pIsHomePage, pVisibility, pHeaderTitle, pHtmlContent)
	VALUES ('ACTIVE', 0, 'Visible', 'ABOUT', '');
INSERT INTO [Page] (pStatus, pIsHomePage, pVisibility, pHeaderTitle, pHtmlContent)
	VALUES ('ACTIVE', 0, 'Visible', 'PRODUCTS', '');
INSERT INTO [Page] (pStatus, pIsHomePage, pVisibility, pHeaderTitle, pHtmlContent)
	VALUES ('ACTIVE', 0, 'Visible', 'CONTACT', '');
INSERT INTO [Page] (pStatus, pIsHomePage, pVisibility, pHeaderTitle, pHtmlContent)
	VALUES ('INACTIVE', 0, 'Visible', 'BLOG', '');