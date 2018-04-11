






Select datename(MONTH, F.Fecha) as Mes, p.Name, sum(D.Importe) as Total From Productos P
	Inner join Detalles D on P.ProductoId=D.ProductoId  inner join
	Facturas F on F.FacturaId = D.FacturaId
	group by  datename(MONTH, F.Fecha),p.Name
	for json path, root('Ventas')
go

create procedure ventas_mes
as
	begin
		Select datename(MONTH, F.Fecha) as Mes, p.Name, sum(D.Importe) as Total, p.ProductoId From Productos P
		Inner join Detalles D on P.ProductoId=D.ProductoId  inner join
		Facturas F on F.FacturaId = D.FacturaId
		group by  datename(MONTH, F.Fecha),p.Name, p.ProductoId
		--for json path, root('Ventas')
	end
go

drop proc ventas_mes

Select  p.Name, sum(D.Importe) as Total From Productos P
		Inner join Detalles D on P.ProductoId=D.ProductoId  inner join
		Facturas F on F.FacturaId = D.FacturaId
		group by  p.Name