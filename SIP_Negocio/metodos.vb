
Option Explicit On


Imports System.IO
Imports System.Net
Imports System.Text

Public Class metodos

    Private s_url As String = "http://www.sunat.gob.pe/w/wapS01Alias?ruc="

    Private s_texto_documento_no_encontrado As String = "El numero Ruc ingresado es invalido"

    Private s_documento_a_buscar As String = ""
    Private b_buscar_por_ruc As Boolean = False
    Private b_buscar_por_dni As Boolean = False
    Private stream_dato_web As MemoryStream

    Private s_prefijo_dni As String = "10"
    Private us_tamagno_documento As UShort = 11

    Public Sub New()

    End Sub

#Region "reemplazo_de_caracteres_especiales"

    Dim s_reemplazar_letra_egne_1 As String = "&#209;"
    Dim s_reemplazar_letra_egne_2 As String = "&#xF1;"

#End Region

#Region "etiquetas_a_buscar_en_web"

    ''**************************************************************
    ''etiquetas a buscar
    ''**************************************************************
    Private etiqueta_numero_y_nombre As String = "N&#xFA;mero Ruc."
    Private etiqueta_antiguo_ruc As String = "Antiguo Ruc."
    Private etiqueta_estado As String = "Estado."
    Private etiqueta_es_agente_retencion As String = "Agente Retenci&#xF3;n IGV."
    Private etiqueta_nombre_comercial As String = "Nombre Comercial."
    Private etiqueta_direccion As String = "Direcci&#xF3;n."
    Private etiqueta_situacion As String = "Situaci&#xF3;n"
    Private etiqueta_telefono As String = "Tel&#xE9;fono(s)."
    Private etiqueta_dependencia As String = "Dependencia."
    Private etiqueta_tipo As String = "Tipo."
    Private etiqueta_inicio_actividades As String = "Inicio Act."
    Private etiqueta_actividad_economica As String = "Act. Econ&#xF3;mica."

#End Region

#Region "textos_que_marcan_inicio_o_final_del_dato"

    ''**************************************************************
    ''etiquetas a buscar para reemplazar por vacio
    ''**************************************************************
    Private etiqueta_html_1 As String = "<b>"
    Private etiqueta_html_2 As String = "</b>"
    Private etiqueta_html_3 As String = "<br/>"
    Private etiqueta_html_4 As String = "<small>"
    Private etiqueta_html_5 As String = "</small>"
    Private etiqueta_html_6 As String = "<strong>"
    Private etiqueta_html_7 As String = "</strong>"
    Private etiqueta_html_8 As String = "<!--"
    Private etiqueta_html_9 As String = "-->"
    Private etiqueta_html_10 As String = "</p>"
    Private etiqueta_html_11 As String = "</card>"
    Private etiqueta_final_documento As String = "</wml>"
#End Region

#Region "variables_para_almacenar_y_devolver_datos_encontrados"

    Private b_dato_encontrado As Boolean = False
    Private s_nombre As String = ""
    Private s_antiguo_ruc As String = ""
    Private s_estado As String = ""
    Private s_agente_retencion As String = ""
    Private s_nombre_comercial As String = ""
    Private s_direccion As String = ""
    Private s_situacion As String = ""
    Private s_telefono As String = ""
    Private s_dependencia As String = ""
    Private s_tipo As String = ""
    Private s_inicio_actividades As String = ""
    Private s_actividad_economica As String = ""

#End Region

#Region "datos_encontrados_del_documento"

    Public ReadOnly Property Dato_Encontrado As Boolean
        Get
            Return b_dato_encontrado
        End Get
    End Property

    Public ReadOnly Property Nombre As String
        Get
            Return s_nombre
        End Get
    End Property

    Public ReadOnly Property Antiguo_RUC As String
        Get
            Return s_antiguo_ruc
        End Get
    End Property

    Public ReadOnly Property Estado As String
        Get
            Return s_estado
        End Get
    End Property

    Public ReadOnly Property Agente_Retencion As String
        Get
            Return s_agente_retencion
        End Get
    End Property

    Public ReadOnly Property Nombre_Comercial As String
        Get
            Return s_nombre_comercial
        End Get
    End Property

    Public ReadOnly Property Direccion As String
        Get
            Return s_direccion
        End Get
    End Property

    Public ReadOnly Property Situacion As String
        Get
            Return s_situacion
        End Get
    End Property

    Public ReadOnly Property Telefono As String
        Get
            Return s_telefono
        End Get
    End Property

    Public ReadOnly Property Dependencia As String
        Get
            Return s_dependencia
        End Get
    End Property

    Public ReadOnly Property Tipo As String
        Get
            Return s_tipo
        End Get
    End Property

    Public ReadOnly Property Inicio_Actividades As String
        Get
            Return s_inicio_actividades
        End Get
    End Property

    Public ReadOnly Property Actividad_Economica As String
        Get
            Return s_actividad_economica
        End Get
    End Property

    Public ReadOnly Property Dato_Web_encontrado As MemoryStream
        Get
            Return stream_dato_web
        End Get
    End Property

#End Region

    Public WriteOnly Property Documento_a_Buscar As String
        Set(value As String)
            s_documento_a_buscar = value
        End Set
    End Property

    Public WriteOnly Property Buscar_por_Ruc As Boolean
        Set(value As Boolean)
            b_buscar_por_ruc = value
        End Set
    End Property

    Public WriteOnly Property Buscar_por_DNI As Boolean
        Set(value As Boolean)
            b_buscar_por_dni = value
        End Set
    End Property

    Public Sub Buscar_el_Documento()

        Dim s_direccion_a_buscar As String = ""
        Dim s_dato_de_la_web As String = ""

        If s_documento_a_buscar.Trim = "" Then GoTo salir

        ''saber si se buscara por ruc o dni
        If b_buscar_por_dni = True Then
            s_documento_a_buscar = s_prefijo_dni & s_documento_a_buscar
            s_documento_a_buscar = s_documento_a_buscar & ultimo_digito_para_dni(s_documento_a_buscar)
        End If

        ''buscar el documento
        s_direccion_a_buscar = s_url & s_documento_a_buscar
        s_dato_de_la_web = obtener_datos_de_la_web(s_direccion_a_buscar)

        ''capturar la pagina web devuelta
        stream_dato_web = New MemoryStream(Encoding.ASCII.GetBytes(s_dato_de_la_web))

        ''varificar si el dato fue encontrado
        If InStr(s_dato_de_la_web, s_texto_documento_no_encontrado, CompareMethod.Text) > 0 Then
            b_dato_encontrado = False
        Else
            b_dato_encontrado = True
        End If

        s_nombre = buscar_dato_en_texto_web(etiqueta_numero_y_nombre, etiqueta_antiguo_ruc, s_dato_de_la_web)
        s_nombre = quitar_ruc_del_nombre(s_nombre)
        s_antiguo_ruc = buscar_dato_en_texto_web(etiqueta_antiguo_ruc, etiqueta_estado, s_dato_de_la_web)
        s_estado = buscar_dato_en_texto_web(etiqueta_estado, etiqueta_es_agente_retencion, s_dato_de_la_web)
        s_agente_retencion = buscar_dato_en_texto_web(etiqueta_es_agente_retencion, etiqueta_nombre_comercial, s_dato_de_la_web)
        s_nombre_comercial = buscar_dato_en_texto_web(etiqueta_nombre_comercial, etiqueta_direccion, s_dato_de_la_web)
        s_direccion = buscar_dato_en_texto_web(etiqueta_direccion, etiqueta_situacion, s_dato_de_la_web)
        s_situacion = buscar_dato_en_texto_web(etiqueta_situacion, etiqueta_telefono, s_dato_de_la_web)
        s_telefono = buscar_dato_en_texto_web(etiqueta_telefono, etiqueta_dependencia, s_dato_de_la_web)
        s_dependencia = buscar_dato_en_texto_web(etiqueta_dependencia, etiqueta_tipo, s_dato_de_la_web)
        s_tipo = buscar_dato_en_texto_web(etiqueta_tipo, etiqueta_inicio_actividades, s_dato_de_la_web)
        s_inicio_actividades = buscar_dato_en_texto_web(etiqueta_inicio_actividades, etiqueta_actividad_economica, s_dato_de_la_web)
        s_actividad_economica = buscar_dato_en_texto_web(etiqueta_actividad_economica, etiqueta_final_documento, s_dato_de_la_web)
salir:

    End Sub

    Public Function obtener_datos_de_la_web(ByVal s_url As String) As String

        Dim s_dato_de_la_web As String = ""

        Try

            s_dato_de_la_web = New StreamReader(WebRequest.Create(s_url).GetResponse.GetResponseStream).ReadToEnd

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        Return s_dato_de_la_web

    End Function

    Private Function buscar_dato_en_texto_web(p_etiqueta_a_buscar_inicio As String, p_etiqueta_a_buscar_final As String, p_texto_web As String) As String

        Dim s_dato As String = ""

        Dim i_inicio_dato As Integer = InStr(p_texto_web, p_etiqueta_a_buscar_inicio, CompareMethod.Text)
        Dim i_fin_dato As Integer = 0
        Dim s_dato_encontrado As String = ""

        If i_inicio_dato > 0 Then
            i_fin_dato = InStr(i_inicio_dato, p_texto_web, p_etiqueta_a_buscar_final)
            If i_fin_dato > 0 Then
                s_dato_encontrado = Mid(p_texto_web, i_inicio_dato, (i_fin_dato - i_inicio_dato))

                ''quitar etiquetas no validas del texto
                s_dato_encontrado = Replace(s_dato_encontrado, p_etiqueta_a_buscar_inicio, "")
                s_dato_encontrado = Replace(s_dato_encontrado, p_etiqueta_a_buscar_final, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_1, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_2, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_3, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_4, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_5, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_6, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_7, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_8, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_9, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_10, "")
                s_dato_encontrado = Replace(s_dato_encontrado, etiqueta_html_11, "")

                s_dato_encontrado = s_dato_encontrado.Trim()
                s_dato_encontrado = reemplazar_caracteres_especiales(s_dato_encontrado)

            End If
        End If

        Return s_dato_encontrado

    End Function

    Private Function reemplazar_caracteres_especiales(p_dato As String) As String

        Dim s_dato As String = ""

        s_dato = Replace(p_dato, s_reemplazar_letra_egne_1, "Ñ")
        s_dato = Replace(s_dato, s_reemplazar_letra_egne_2, "Ñ")

        Return s_dato

    End Function

    Private Function quitar_ruc_del_nombre(p_dato As String) As String

        Dim s_nuevo_dato As String = ""
        Dim i_desde As Integer = InStr(p_dato, "-")

        If i_desde > 0 Then
            s_nuevo_dato = Mid(p_dato, i_desde + 1, p_dato.Length)
            s_nuevo_dato = s_nuevo_dato.Trim
        End If

        Return s_nuevo_dato

    End Function

    Private Function ultimo_digito_para_dni(ByVal p_numero_documento As String) As Integer

        If Not IsNumeric(p_numero_documento) Then Return 0

        Dim rango_digitos As Integer() = New Integer() {5, 4, 3, 2, 7, 6, 5, 4, 3, 2}
        Dim num5 As Integer = 0
        Dim num7 As Integer = (p_numero_documento.Length - 1)
        Dim i As Integer = 0

        Try

            Do While (i <= num7)
                num5 = (num5 + (Integer.Parse(p_numero_documento.Substring(i, 1)) * rango_digitos(i)))
                i += 1
            Loop

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        Dim num3 As Integer = (num5 Mod us_tamagno_documento)
        Dim num4 As Integer = (us_tamagno_documento - num3)
        Select Case num4
            Case 10
                Return 0
            Case 11
                Return 1
        End Select

        Return num4

    End Function


End Class
