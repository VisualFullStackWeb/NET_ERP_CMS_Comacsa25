Public Class ETGuia

    Private _Ancho As Decimal
    Private _Ano As String
    Private _Cant_Anterior As Decimal
    Private _Cant_Dev As Decimal
    Private _Cant_Ing As Decimal
    Private _Cant_OC As Decimal
    Private _Cant_Ped As Decimal
    Private _CapacTransp As Decimal
    Private _Cod_Alm As String
    Private _cod_Alm2 As String
    Private _Cod_Area As String
    Private _Cod_Cantera As String
    Private _Cod_Cia As String
    Private _Cod_Cli As String
    Private _Cod_Empleo As String
    Private _Cod_Equipo As String
    Private _Cod_Labor As String
    Private _Cod_Per As String
    Private _Cod_Prod As String
    Private _Cod_ProdPdc As String
    Private _CodOrigen As String
    Private _Colaborador As String
    Private _CostoMin As Decimal
    Private _CtaCosto As String
    Private _Dcto As Decimal
    Private _Descrip As String
    Private _Dia As String
    Private _Doc_Ori As String
    Private _Encajado As Boolean
    Private _Espesor As Decimal
    Private _Facturado As String
    Private _Hrs_Lab As Decimal
    Private _IndicadorEnvio As String
    Private _Item As Integer
    Private _Item_Fact As Integer
    Private _Item_Pedido As Integer
    Private _Kilometraje As Decimal
    Private _Largo As Decimal
    Private _Lleno As Boolean
    Private _Mes As String
    Private _Moneda As String
    Private _Mov_Stock As String
    Private _Movi As String
    Private _Nro_BlsFin As String
    Private _Nro_BlsIni As String
    Private _NroHrs As Decimal
    Private _Num_Ord_Exp As String
    Private _NumDoc As String
    Private _NumDocRef As String
    Private _NumDoc2 As String
    Private _NumInterno As String
    Private _NumeroRequisicion As String
    Private _Obs As String
    Private _Obs_Pedido As String
    Private _Peso_Aduanas As Decimal
    Private _Peso_Bls As Decimal
    Private _Peso_Contenedor As Decimal
    Private _Piezas As Decimal
    Private _Precio As Decimal
    Private _PtoVta As String
    Private _RazSoc As String
    Private _Ruc As String
    Private _Status As String
    Private _TipDocRef As String
    Private _Tipo_Cambio As Decimal
    Private _Tipo_Doc As String
    Private _Tipo_DocOri As String
    Private _Tipo_Mov As String
    Private _TipoDespacho As String
    Private _TipProd As String
    Private _Total As Decimal
    Private _Und_OC As String
    Private _Unid As String
    Private _User_Crea As String
    Private _Valorizacion As Decimal
    Private _Dir As String
    Private _Dir2 As String
    Private _Cod_Ubi As String
    Private _Cod_Ubi2 As String
    Private _Motivo As String
    Private _Factm As Decimal
    Private _NumInternoExp As String
    Private _Fecha As DateTime
    Private _Fecha2 As DateTime


    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Public Property Fecha2() As DateTime
        Get
            Return _Fecha2
        End Get
        Set(ByVal value As DateTime)
            _Fecha2 = value
        End Set
    End Property

    Public Property NumInternoExp() As String
        Get
            Return _NumInternoExp
        End Get
        Set(ByVal value As String)
            _NumInternoExp = value
        End Set
    End Property

    Public Property Factm() As Decimal
        Get
            Return _Factm
        End Get
        Set(ByVal value As Decimal)
            _Factm = value
        End Set
    End Property


    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal value As String)
            _Motivo = value
        End Set
    End Property

    Public Property Dir() As String
        Get
            Return _Dir
        End Get
        Set(ByVal value As String)
            _Dir = value
        End Set
    End Property

    Public Property Dir2() As String
        Get
            Return _Dir2
        End Get
        Set(ByVal value As String)
            _Dir2 = value
        End Set
    End Property

    Public Property Cod_Ubi() As String
        Get
            Return _Cod_Ubi
        End Get
        Set(ByVal value As String)
            _Cod_Ubi = value
        End Set
    End Property

    Public Property Cod_Ubi2() As String
        Get
            Return _Cod_Ubi2
        End Get
        Set(ByVal value As String)
            _Cod_Ubi2 = value
        End Set
    End Property



    Public Property Ancho() As Decimal
        Get
            Return _Ancho
        End Get
        Set(ByVal value As Decimal)
            _Ancho = value
        End Set
    End Property

    Public Property Ano() As String
        Get
            Return _Ano
        End Get
        Set(ByVal value As String)
            _Ano = value
        End Set
    End Property

    Public Property Cant_Anterior() As Decimal
        Get
            Return _Cant_Anterior
        End Get
        Set(ByVal value As Decimal)
            _Cant_Anterior = value
        End Set
    End Property

    Public Property Cant_Dev() As Decimal
        Get
            Return _Cant_Dev
        End Get
        Set(ByVal value As Decimal)
            _Cant_Dev = value
        End Set
    End Property

    Public Property Cant_Ing() As Decimal
        Get
            Return _Cant_Ing
        End Get
        Set(ByVal value As Decimal)
            _Cant_Ing = value
        End Set
    End Property

    Public Property Cant_OC() As Decimal
        Get
            Return _Cant_OC
        End Get
        Set(ByVal value As Decimal)
            _Cant_OC = value
        End Set
    End Property


    Public Property Cant_Ped() As Decimal
        Get
            Return _Cant_Ped
        End Get
        Set(ByVal value As Decimal)
            _Cant_Ped = value
        End Set
    End Property

    Public Property CapacTransp() As Decimal
        Get
            Return _CapacTransp
        End Get
        Set(ByVal value As Decimal)
            _CapacTransp = value
        End Set
    End Property


    Public Property Cod_Alm() As String
        Get
            Return _Cod_Alm
        End Get
        Set(ByVal value As String)
            _Cod_Alm = value
        End Set
    End Property

    Public Property Cod_Alm2() As String
        Get
            Return _cod_Alm2
        End Get
        Set(ByVal value As String)
            _cod_Alm2 = value
        End Set
    End Property

    Public Property Cod_Area() As String
        Get
            Return _Cod_Area
        End Get
        Set(ByVal value As String)
            _Cod_Area = value
        End Set
    End Property

    Public Property Cod_Cantera() As String
        Get
            Return _Cod_Cantera
        End Get
        Set(ByVal value As String)
            _Cod_Cantera = value
        End Set
    End Property

    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property

    Public Property Cod_Cli() As String
        Get
            Return _Cod_Cli
        End Get
        Set(ByVal value As String)
            _Cod_Cli = value
        End Set
    End Property

    Public Property Cod_Empleo() As String
        Get
            Return _Cod_Empleo
        End Get
        Set(ByVal value As String)
            _Cod_Empleo = value
        End Set
    End Property

    Public Property Cod_Equipo() As String
        Get
            Return _Cod_Equipo
        End Get
        Set(ByVal value As String)
            _Cod_Equipo = value
        End Set
    End Property

    Public Property Cod_Labor() As String
        Get
            Return _Cod_Labor
        End Get
        Set(ByVal value As String)
            _Cod_Labor = value
        End Set
    End Property

    Public Property Cod_Per() As String
        Get
            Return _Cod_Per
        End Get
        Set(ByVal value As String)
            _Cod_Per = value
        End Set
    End Property

    Public Property Cod_Prod() As String
        Get
            Return _Cod_Prod
        End Get
        Set(ByVal value As String)
            _Cod_Prod = value
        End Set
    End Property

    Public Property Cod_ProdPdc() As String
        Get
            Return _Cod_ProdPdc
        End Get
        Set(ByVal value As String)
            _Cod_ProdPdc = value
        End Set
    End Property

    Public Property CodOrigen() As String
        Get
            Return _CodOrigen
        End Get
        Set(ByVal value As String)
            _CodOrigen = value
        End Set
    End Property

    Public Property Colaborador() As String
        Get
            Return _Colaborador
        End Get
        Set(ByVal value As String)
            _Colaborador = value
        End Set
    End Property

    Public Property CostoMin() As Decimal
        Get
            Return _CostoMin
        End Get
        Set(ByVal value As Decimal)
            _CostoMin = value
        End Set
    End Property

    Public Property CtaCosto() As String
        Get
            Return _CtaCosto
        End Get
        Set(ByVal value As String)
            _CtaCosto = value
        End Set
    End Property

    Public Property Dcto() As Decimal
        Get
            Return _Dcto
        End Get
        Set(ByVal value As Decimal)
            _Dcto = value
        End Set
    End Property

    Public Property Descrip() As String
        Get
            Return _Descrip
        End Get
        Set(ByVal value As String)
            _Descrip = value
        End Set
    End Property

    Public Property Dia() As String
        Get
            Return _Dia
        End Get
        Set(ByVal value As String)
            _Dia = value
        End Set
    End Property

    Public Property Doc_Ori() As String
        Get
            Return _Doc_Ori
        End Get
        Set(ByVal value As String)
            _Doc_Ori = value
        End Set
    End Property

    Public Property Encajado() As Boolean
        Get
            Return _Encajado
        End Get
        Set(ByVal value As Boolean)
            _Encajado = value
        End Set
    End Property

    Public Property Espesor() As Decimal
        Get
            Return _Espesor
        End Get
        Set(ByVal value As Decimal)
            _Espesor = value
        End Set
    End Property

    Public Property Facturado() As String
        Get
            Return _Facturado
        End Get
        Set(ByVal value As String)
            _Facturado = value
        End Set
    End Property

    Public Property Hrs_Lab() As Decimal
        Get
            Return _Hrs_Lab
        End Get
        Set(ByVal value As Decimal)
            _Hrs_Lab = value
        End Set
    End Property

    Public Property IndicadorEnvio() As String
        Get
            Return _IndicadorEnvio
        End Get
        Set(ByVal value As String)
            _IndicadorEnvio = value
        End Set
    End Property

    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property

    Public Property Item_Fact() As Integer
        Get
            Return _Item_Fact
        End Get
        Set(ByVal value As Integer)
            _Item_Fact = value
        End Set
    End Property

    Public Property Item_Pedido() As Integer
        Get
            Return _Item_Pedido
        End Get
        Set(ByVal value As Integer)
            _Item_Pedido = value
        End Set
    End Property

    Public Property Kilometraje() As Decimal
        Get
            Return _Kilometraje
        End Get
        Set(ByVal value As Decimal)
            _Kilometraje = value
        End Set
    End Property

    Public Property Largo() As Decimal
        Get
            Return _Largo
        End Get
        Set(ByVal value As Decimal)
            _Largo = value
        End Set
    End Property

    Public Property Lleno() As Boolean
        Get
            Return _Lleno
        End Get
        Set(ByVal value As Boolean)
            _Lleno = value
        End Set
    End Property

    Public Property Mes() As String
        Get
            Return _Mes
        End Get
        Set(ByVal value As String)
            _Mes = value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property

    Public Property Mov_Stock() As String
        Get
            Return _Mov_Stock
        End Get
        Set(ByVal value As String)
            _Mov_Stock = value
        End Set
    End Property

    Public Property Movi() As String
        Get
            Return _Movi
        End Get
        Set(ByVal value As String)
            _Movi = value
        End Set
    End Property

    Public Property Nro_BlsFin() As String
        Get
            Return _Nro_BlsFin
        End Get
        Set(ByVal value As String)
            _Nro_BlsFin = value
        End Set
    End Property

    Public Property Nro_BlsIni() As String
        Get
            Return _Nro_BlsIni
        End Get
        Set(ByVal value As String)
            _Nro_BlsIni = value
        End Set
    End Property

    Public Property NroHrs() As Decimal
        Get
            Return _NroHrs
        End Get
        Set(ByVal value As Decimal)
            _NroHrs = value
        End Set
    End Property


    Public Property Num_Ord_Exp() As String
        Get
            Return _Num_Ord_Exp
        End Get
        Set(ByVal value As String)
            _Num_Ord_Exp = value
        End Set
    End Property

    Public Property NumDoc() As String
        Get
            Return _NumDoc
        End Get
        Set(ByVal value As String)
            _NumDoc = value
        End Set
    End Property

    Public Property NumDocRef() As String
        Get
            Return _NumDocRef
        End Get
        Set(ByVal value As String)
            _NumDocRef = value
        End Set
    End Property

    Public Property NumDoc2() As String
        Get
            Return _NumDoc2
        End Get
        Set(ByVal value As String)
            _NumDoc2 = value
        End Set
    End Property

    Public Property NumInterno() As String
        Get
            Return _NumInterno
        End Get
        Set(ByVal value As String)
            _NumInterno = value
        End Set
    End Property

    Public Property NumeroRequisicion() As String
        Get
            Return _NumeroRequisicion
        End Get
        Set(ByVal value As String)
            _NumeroRequisicion = value
        End Set
    End Property

    Public Property Obs() As String
        Get
            Return _Obs
        End Get
        Set(ByVal value As String)
            _Obs = value
        End Set
    End Property

    Public Property Obs_Pedido() As String
        Get
            Return _Obs_Pedido
        End Get
        Set(ByVal value As String)
            _Obs_Pedido = value
        End Set
    End Property

    Public Property Peso_Aduanas() As Decimal
        Get
            Return _Peso_Aduanas
        End Get
        Set(ByVal value As Decimal)
            _Peso_Aduanas = value
        End Set
    End Property

    Public Property Peso_Bls() As Decimal
        Get
            Return _Peso_Bls
        End Get
        Set(ByVal value As Decimal)
            _Peso_Bls = value
        End Set
    End Property

    Public Property Peso_Contenedor() As Decimal
        Get
            Return _Peso_Contenedor
        End Get
        Set(ByVal value As Decimal)
            _Peso_Contenedor = value
        End Set
    End Property

    Public Property Piezas() As Decimal
        Get
            Return _Piezas
        End Get
        Set(ByVal value As Decimal)
            _Piezas = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property

    Public Property PtoVta() As String
        Get
            Return _PtoVta
        End Get
        Set(ByVal value As String)
            _PtoVta = value
        End Set
    End Property

    Public Property RazSoc() As String
        Get
            Return _RazSoc
        End Get
        Set(ByVal value As String)
            _RazSoc = value
        End Set
    End Property

    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Public Property TipDocRef() As String
        Get
            Return _TipDocRef
        End Get
        Set(ByVal value As String)
            _TipDocRef = value
        End Set
    End Property

    Public Property Tipo_Cambio() As Decimal
        Get
            Return _Tipo_Cambio
        End Get
        Set(ByVal value As Decimal)
            _Tipo_Cambio = value
        End Set
    End Property

    Public Property Tipo_Doc() As String
        Get
            Return _Tipo_Doc
        End Get
        Set(ByVal value As String)
            _Tipo_Doc = value
        End Set
    End Property

    Public Property Tipo_DocOri() As String
        Get
            Return _Tipo_DocOri
        End Get
        Set(ByVal value As String)
            _Tipo_DocOri = value
        End Set
    End Property

    Public Property Tipo_Mov() As String
        Get
            Return _Tipo_Mov
        End Get
        Set(ByVal value As String)
            _Tipo_Mov = value
        End Set
    End Property

    Public Property TipoDespacho() As String
        Get
            Return _TipoDespacho
        End Get
        Set(ByVal value As String)
            _TipoDespacho = value
        End Set
    End Property

    Public Property TipProd() As String
        Get
            Return _TipProd
        End Get
        Set(ByVal value As String)
            _TipProd = value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property

    Public Property Und_OC() As String
        Get
            Return _Und_OC
        End Get
        Set(ByVal value As String)
            _Und_OC = value
        End Set
    End Property

    Public Property Unid() As String
        Get
            Return _Unid
        End Get
        Set(ByVal value As String)
            _Unid = value
        End Set
    End Property

    Public Property User_Crea() As String
        Get
            Return _User_Crea
        End Get
        Set(ByVal value As String)
            _User_Crea = value
        End Set
    End Property

    Public Property Valorizacion() As Decimal
        Get
            Return _Valorizacion
        End Get
        Set(ByVal value As Decimal)
            _Valorizacion = value
        End Set
    End Property


End Class
