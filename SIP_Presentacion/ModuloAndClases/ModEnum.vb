Module ModEnum

    Public Enum Permisos
        Ingreso = 1
        Form = 2
        Operacion = 3
        Reporte = 4
    End Enum

    Public Enum Operacion
        Retorno = 0
        Nuevo = 1
        Modificar = 2
        Eliminar = 3
        Buscar = 4
        Grabar = 5
        Cancelar = 6
        Procesar = 7
        Reporte = 8
        Actualizar = 9
        Consultar = 10
        Correo = 11
        Excel = 12
        Stock = 13
        Pedido = 14
        Manual = 15
        Word = 16
        Pdf = 17
    End Enum

    Public Enum VarReporte
        Orden = 1
        Requerimiento = 2
        Exportacion = 3
        ProductoxRuma = 4
        Formula = 5
        ProductoxUnidad = 6
        RequerimientoCompra = 7
        CosteoProduccionxMolino = 8
        CosteoProduccionxProducto = 9
        ProductoxMinerales = 10
        TrazabilidadProforma = 11
        DocumentoCrystal = 12
    End Enum

    Public Enum ExpArchivo
        Word = 1
        Excel = 2
        Pdf = 3
    End Enum

    Public Enum uStatus
        Procesando = 1
        Finalizado = 2
    End Enum

End Module
