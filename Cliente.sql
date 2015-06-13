use Soapet
create table cliente(
idcliente varchar(50),
nombre varchar(50),
ape_paterno varchar(50),
ape_materno varchar(50),
telefono varchar(20),
celular varchar(20),
correo varchar(50),
direccion varchar(100),
dni varchar(08)

 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

