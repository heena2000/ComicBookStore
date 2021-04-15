GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'76802088-a9bb-4532-9b8d-d29e516c8652', N'admin', N'admin', N'2cad3ca1-b535-4e60-8b17-7e61b98897b0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bf427433-99f5-4615-87e9-3d809574a016', N'admin@cbs.com', N'ADMIN@CBS.COM', N'admin@cbs.com', N'ADMIN@CBS.COM', 1, N'AQAAAAEAACcQAAAAEOlbQZUgD10Aa4mMvXL7zqL6McsuphbGeRGVBy29T3Yjv706FsLYBIMvfouWx4WaUg==', N'LOZ2I7XTMIS3QUPH3WYP4E7AWDTDGQJ2', N'ce48aae8-22de-4314-9ce4-90087673dbfd', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e3dc608c-ac38-46b5-bcdf-ededd2773289', N'user@cbs.com', N'USER@CBS.COM', N'user@cbs.com', N'USER@CBS.COM', 1, N'AQAAAAEAACcQAAAAEGD1q/00VDPIoqL4xDWwP2r67TsozxJXXuAqasY40WdXspXv1NABdiOwdsTz6iKxag==', N'PHJKXS73YWBTRQEA6GQVBGYB2IDGGFA7', N'd9179a91-4a30-484d-a5cf-c42cdafda016', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bf427433-99f5-4615-87e9-3d809574a016', N'76802088-a9bb-4532-9b8d-d29e516c8652')
GO
SET IDENTITY_INSERT [dbo].[ComicCategories] ON 
GO
INSERT [dbo].[ComicCategories] ([CategoryID], [CategoryName]) VALUES (1, N'Single Issues')
GO
INSERT [dbo].[ComicCategories] ([CategoryID], [CategoryName]) VALUES (2, N'Graphic Novels')
GO
SET IDENTITY_INSERT [dbo].[ComicCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[ComicCompanies] ON 
GO
INSERT [dbo].[ComicCompanies] ([CompanyID], [CompanyName]) VALUES (1, N'MARVEL COMICS')
GO
INSERT [dbo].[ComicCompanies] ([CompanyID], [CompanyName]) VALUES (2, N'DC COMICS')
GO
SET IDENTITY_INSERT [dbo].[ComicCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[ComicInfos] ON 
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (1, N'Secret Empire #10', N'This is a variant cover by Gabrielle Dell’otto Can there be any redemption for Captain America as the SECRET EMPIRE starts to crumble?', 41, 49.98, N'.PNG', 1, 1)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (2, N'Venom First Host #1', N'This is a variant cover by Rod Reiss
MIKE COSTA AND MARK BAGLEY REUNITE FOR A VENOM STORY UNLIKE ANY OTHER! Before the AMAZING SPIDER-MAN…before VENOM… There was the FIRST HOST. And that First Host has returned in need of Venom’s help – only by reuniting can the two avert cosmic ruin! Can Eddie and the symbiote trust one another long enough to save the galaxy, or will the FIRST HOST prove to be Venom’s undoing?! Rated T+', 45, 79.98, N'.PNG', 1, 1)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (3, N'Web of Venom: Carnage Born #1 Ian Bederman Variant Cover', N'oin DONNY CATES as he continues to snake his tendrils through the VENOM mythos – this time visiting the sickening sociopath called CARNAGE! A cruel cannibal obsessed with death and murder, few mourned Cletus Kasady after he seemingly died in VENOMIZED. But now a cult devoted to the madman has gathered, hoping to resurrect their fallen idol and return his madness to the Marvel Universe…', 32, 29.98, N'.PNG', 1, 1)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (4, N'Avengers Vol. 5: Infinite Avengers', N'Original Sin tie-in! What sinister secrets will the Avengers uncover? Plus, propelled 50 years into the future, the Avengers come face-to-face with the legacy of their actions! Collecting Avengers Vol.5 #24-28.', 32, 19.98, N'.PNG', 1, 2)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (5, N'Doctor Strange And The Sorcerers Supreme Vol. 2', N'Sir Isaac Newton, has mastered an ancient, evil magic, gone power-mad, and betrayed the rest of the Sorcerers Supreme! Now, it is up to the Doctor Strange and the remaining Sorcerers Supreme to stop him from sending the world and all of their own individual timelines into chaos! But even with the Avengers on their side, will it be enough to stop Newton?!! Collecting Doctor Strange and the Sorcerers Supreme #7-11 (subject to change).', 32, 11.98, N'.PNG', 1, 2)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (6, N'Black Panther #1 CGC 7.5', N'Marvel legend Jack Kirby presents Black Panther in his first ongoing series! While helping Abner Little recollect a precious artifact, Black Panther runs afoul of the Collectors! And in the midst of the tussle…an ancient time machine is activated! Enter Hatch-22, a creature from a time and space unknown.', 30, 15.98, N'.PNG', 1, 2)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (7, N'Dark Nights Death Metal Trinity Crisis One Shot Incentive Variant Cover', N'This is a 1:25 variant incentive cover by Kyle Hotz
With Superman freed from his New Apokolips prison, the classic Trinity lineup is reunited and ready to rock! Wonder Woman, Batman, and Superman amp up their power to launch an assault on Castle Bat, and that’s just the warm-up act! Three walking nightmares are hidden deep inside the fortress-but these Dark Multiverse versions of the Anti-Monitor, Superboy Prime, and Darkseid hold the key to humanity’s survival. The Justice League have to face down their old nemeses, but will round two be the end for our heroes?', 38, 119.98, N'.PNG', 2, 1)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (8, N'Tales From The Dark Multiverse Crisis On Infinite Earths #1', N'When the Anti-Monitor’s deadly grudge match with the Multiverse was finally foiled, there was only one Earth left! But which Earth? That was crucial to what would happen next. In one timeline, Earth-1’s Superman stopped the Superman of Earth-2 from going into final battle, but in the Dark Multiverse, it’s Jor-L of Earth-2 who survives, changing the landscape for all that follows. When Surtur comes looking to crush all life, the beleaguered heroes jump into their next big battle, jumping from one Crisis to the next…but will the last days of the Justice Society of America play out differently if Green Lantern Alan Scott can step into the darkness?', 53, 39.98, N'.PNG', 2, 1)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (9, N'Joker 80th Anniversary 100-Page Super Spectacular #1', N'The Clown Prince of Crime celebrates 80 years of chaos! The Joker has been the greatest villain in comics since his debut and to celebrate we have a who’s who of comics’ finest talent giving the Harlequin of Hate the birthday roast he deserves. The stories feature a range of terror and anarchy, showing how the Joker has impacted Gotham City from the police to Arkham Asylum, from the local underworld to the Dark Knight and his allies! Make sure to RSVP to this birthday bash-you wouldn’t want to wake up with a Joker Fish on your doorstep, would you?', 100, 69.98, N'.PNG', 2, 1)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (10, N'Tales from the Dark Multiverse: Flashpoint #1', N'Spinning out of the events of a world where a single choice by the Flash affected the entire DC Universe, find out what would have happened if Barry Allen had not put things right. In a world where the Flashpoint reality was never undone, where Thomas Wayne still haunts Gotham City as the Batman, and the Amazonian and Atlantean armies still prepare for war, will the Reverse-Flash embrace this darker, deadlier world and finally eclipse Barry Allen’s legacy?', 38, 39.98, N'.PNG', 2, 2)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (11, N'Cursed Comics Cavalcade #1', N'Horror! Death! Uh…Face-punching! Witness ten all-new stories that promise to be the most terrifying, most shocking and most horrific comic that DC Comics has ever published! (Hyperbole much?) Batman, Wonder Woman, Guy Gardner, Swamp Thing, Zatanna, and more of your favorite heroes face unspeakable horrors from the streets of Gotham City to the darkest sectors of the universe.', 41, 29.98, N'.PNG', 2, 2)
GO
INSERT [dbo].[ComicInfos] ([ComicID], [ComicName], [Description], [Pages], [Price], [Extension], [CompanyID], [CategoryID]) VALUES (12, N'JUSTICE LEAGUE VOL 01 ORIGIN', N'In a universe where Super Heroes are strange and new, Batman has discovered a dark evil that requires him to unite the World Greatest Heroes! Superman, Batman, Wonder Woman, Green Lantern, Aquaman, The Flash and Cyborg unite for the first time to form the JUSTICE LEAGUE!
Don’t miss the thrill-a-minute collection of the first six issues of the best-selling comic!', 43, 18.98, N'.PNG', 2, 2)
GO
SET IDENTITY_INSERT [dbo].[ComicInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[ComicOrders] ON 
GO
INSERT [dbo].[ComicOrders] ([OrderID], [Address], [OrderDate], [UserID], [Quantity], [Price], [Total], [ComicID], [ComicInfoComicID]) VALUES (1, N'Street 10 Auckland', CAST(N'2021-04-12T00:49:01.6709974' AS DateTime2), N'user@cbs.com', 3, 11.98, 35.94, 5, NULL)
GO
SET IDENTITY_INSERT [dbo].[ComicOrders] OFF
GO
