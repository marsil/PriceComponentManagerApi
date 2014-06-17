CREATE TABLE [dbo].[Exception](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [varchar](100) NOT NULL,
	[Url] [varchar](500) NOT NULL,
	[Parameters] [varchar](500) NOT NULL,
	[Message] [varchar](1000) NOT NULL,
	[Source] [varchar](1000) NOT NULL,
	[StackTrace] [ntext] NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Exception] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]