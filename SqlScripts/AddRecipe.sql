DECLARE @Id UNIQUEIDENTIFIER = NEWID();
DECLARE @Name NVARCHAR(250) = 'Couscous';
DECLARE @Link NVARCHAR(2500) = 'https://www.amazon.de/tegut-gute-Lebensmittel-207511-Couscous/dp/B07HFDJLM6/ref=sr_1_3_f3_wg?__mk_de_DE=%C3%85M%C3%85%C5%BD%C3%95%C3%91&almBrandId=QW1hem9uIEZyZXNo&crid=1SVGN7HBUH992&dib=eyJ2IjoiMSJ9.I-y7ZiwM94BW68X0NbRczMhRax1XUtbAKNmxEx2SS1EhlX4Xe70w15GkD_rD4dyJI4bNCif6K9d7AAVOPrpKt0kcIQcmO-pMNpKWVxZkspOQYli-gj6t7wtDuZX_Af7rRE1QDYBxNw4TaT0sGHZft2u7QHyBMkhSvRcZKKzzzqhwJDGrpda6--96uRY-oEp7._CtibFtg480b5tbEjp_b2JBRzdzgBSmAAWYgOptbo8c&dib_tag=se&fpw=alm&keywords=couscous&qid=1721725839&s=amazonfresh&sprefix=couscous%2Camazonfresh%2C163&sr=1-3';
DECLARE @QuantityInPackInGramsOrMl INT = 500;
DECLARE @QuantityInPcs INT = null;
DECLARE @DateAdded DATETIME = SYSUTCDATETIME();

EXEC [dbo].[INSERT_FoodItem]
    @Id,
    @Name,
    @Link,
    @QuantityInPackInGramsOrMl,
    @QuantityInPcs,
	@DateAdded
