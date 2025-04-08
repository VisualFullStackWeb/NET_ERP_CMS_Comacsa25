Imports SIP_Negocio
Imports SIP_Entidad
Public Class ClsMenu

    Private ObjOperacion As Object


    Public Sub Evento_Click(ByVal Opcion As Int16, ByVal Formulario As Form)

        If Formulario Is Nothing Then
            Return
        End If

        ObjOperacion = New Object
        ObjOperacion = Formulario

        Try
            Select Case Opcion
                Case Operacion.Nuevo : ObjOperacion.Nuevo()
                Case Operacion.Modificar : ObjOperacion.Modificar()
                Case Operacion.Cancelar : ObjOperacion.Cancelar()
                Case Operacion.Eliminar : ObjOperacion.Eliminar()
                Case Operacion.Buscar :  ObjOperacion.Buscar()
                Case Operacion.Grabar : ObjOperacion.Grabar()
                Case Operacion.Procesar : ObjOperacion.Procesar()
                Case Operacion.Reporte : ObjOperacion.Reporte()
                Case Operacion.Actualizar : ObjOperacion.Actualizar()
                Case Operacion.Excel : ObjOperacion.Excel()
                Case Operacion.Word : ObjOperacion.Word()
                Case Operacion.Pdf : ObjOperacion.Pdf()
                Case Operacion.Stock : ObjOperacion.Stock()
                Case Operacion.Pedido : ObjOperacion.Pedido()
                Case Operacion.Manual : ObjOperacion.Manual()
                Case Else
            End Select
        Catch
            MessageBox.Show("Error: Ocurrio un Problema al Compilar la Aplicacion", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


End Class
