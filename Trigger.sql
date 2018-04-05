CREATE TRIGGER  enter_detail  on Detalles
after INSERT
AS
 BEGIN
	declare @cantidad_N int
	declare @id int
	declare @cantidad_V int
	SET NOCOUNT ON; 
	BEGIN 

		select @id = ProductoId from inserted
		select @cantidad_V = Cantidad from Productos where ProductoId=@id
		Select @cantidad_N = Cantidad From inserted
		update Productos set Cantidad=@cantidad_V-@cantidad_N where ProductoId =@id
		--print concat('id-',@id,'- cantidad v',@cantidad_v,'-cantidad n', @cantidad_N);
	END 
END
go