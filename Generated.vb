' Handle Mauro base types through an import alias
Imports uuid = System.Guid
Imports mandatoryString = System.String
Imports multiplicity = System.Int32

' JSON 
Imports System.Text.Json
Imports System.Text.Json.Serialization

''' <summary>
''' The Mauro Data Model
''' </summary>
Namespace Mauro


    Enum dataTypeDomainTypeEnum
        PrimitiveType
        ReferenceType
        EnumerationType
    End Enum
    Enum dataModelTypeEnum
        Data_Asset
        Data_Standard
    End Enum

    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class catalogueItem
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataTypesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataTypeType</returns>
        <JsonPropertyName("dataType")>
        Public Property dataType As dataTypeType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class metadataCollectionType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class metadataType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("namespace")>
        Public Property [namespace] As String
        ' ############## WARNING ##############
        ' The model uses the Visual Basic keyword namespace - this has been escaped to [namespace] - Consider refactoring
        ' ############## WARNING ##############
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("key")>
        Public Property key As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("value")>
        Public Property value As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class enumerationValueType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("value")>
        Public Property value As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("key")>
        Public Property key As String
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataClassType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataClassesType</returns>
        <JsonPropertyName("childDataClasses")>
        Public Property childDataClasses As dataClassesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataElementsType</returns>
        <JsonPropertyName("childDataElements")>
        Public Property childDataElements As dataElementsType
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("maxMultiplicity")>
        Public Property maxMultiplicity As multiplicity
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("minMultiplicity")>
        Public Property minMultiplicity As multiplicity
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class enumerationValuesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>enumerationValueType</returns>
        <JsonPropertyName("enumerationValue")>
        Public Property enumerationValue As enumerationValueType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataElementsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataElementType</returns>
        <JsonPropertyName("dataElement")>
        Public Property dataElement As dataElementType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class classifierType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataModels
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataModel</returns>
        <JsonPropertyName("dataModel")>
        Public Property dataModel As dataModel
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataElementType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("minMultiplicity")>
        Public Property minMultiplicity As multiplicity
        ''' <summary>
        ''' If you've already provided the full DataType information in the DataModel list of DataTypes, then you need only provide the label and domainType here to link to the DataType. If you have not provided all the information at the DataModel level then a DataType will be created using the information provided. 
        ''' </summary>
        ''' <returns>dataTypeType</returns>
        <JsonPropertyName("dataType")>
        Public Property dataType As dataTypeType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
        ''' <summary>
        ''' If not provided then will default to 1 (required) 
        ''' </summary>
        ''' <returns>multiplicity</returns>
        <JsonPropertyName("maxMultiplicity")>
        Public Property maxMultiplicity As multiplicity
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class annotationsType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationType</returns>
        <JsonPropertyName("annotation")>
        Public Property annotation As annotationType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("alias")>
        Public Property [alias] As String
        ' ############## WARNING ##############
        ' The model uses the Visual Basic keyword alias - this has been escaped to [alias] - Consider refactoring
        ' ############## WARNING ##############
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataClassesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataClassType</returns>
        <JsonPropertyName("dataClass")>
        Public Property dataClass As dataClassType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifierType</returns>
        <JsonPropertyName("classifier")>
        Public Property classifier As classifierType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class annotationType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' Only optional if is a child annotation, the top level annotation must have a label 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("childAnnotations")>
        Public Property childAnnotations As annotationsType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataModel
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>boolean</returns>
        <JsonPropertyName("finalised")>
        Public Property finalised As Boolean
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataModelTypeEnum</returns>
        <JsonPropertyName("type")>
        Public Property type As dataModelTypeEnum
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
        ''' <summary>
        ''' If adding a DataModel which already exists in the Metadata Catalogue then this must be provided and be a later version to the one in the Catalogue. Otherwise you will get an import error due to non-unique labels 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("documentationVersion")>
        Public Property documentationVersion As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("author")>
        Public Property author As String
        ''' <summary>
        ''' Whilst it is preferable to provide the list of DataTypes here and then use the label and domainType to link from the DataElement, you can provide the DataType information at the DataElement level. However be aware that any DataTypes which use the same label will use the first set of information found for all DataElements which use this DataType, therefore any differences in, say enumerations, will be lost. This is why it is better to provide the list of DataTypes upfront. 
        ''' </summary>
        ''' <returns>dataTypesType</returns>
        <JsonPropertyName("dataTypes")>
        Public Property dataTypes As dataTypesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
        ''' <summary>
        ''' If finalised is true then this element is NOT optional 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("dateFinalised")>
        Public Property dateFinalised As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("organisation")>
        Public Property organisation As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataClassesType</returns>
        <JsonPropertyName("childDataClasses")>
        Public Property childDataClasses As dataClassesType
    End Class
    ''' <summary>
    ''' ##TODO Add description comment
    ''' </summary>
    Public Class dataTypeType
        ''' <summary>
        ''' Mandatory if domainType is "EnumerationType". Ignored otherwise 
        ''' </summary>
        ''' <returns>enumerationValuesType</returns>
        <JsonPropertyName("enumerationValues")>
        Public Property enumerationValues As enumerationValuesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dateTime</returns>
        <JsonPropertyName("lastUpdated")>
        Public Property lastUpdated As DateTime
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>dataTypeDomainTypeEnum</returns>
        <JsonPropertyName("domainType")>
        Public Property domainType As dataTypeDomainTypeEnum
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>uuid</returns>
        <JsonPropertyName("id")>
        Public Property id As uuid
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>aliasesType</returns>
        <JsonPropertyName("aliases")>
        Public Property aliases As aliasesType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>annotationsType</returns>
        <JsonPropertyName("annotations")>
        Public Property annotations As annotationsType
        ''' <summary>
        ''' Mandatory if domainType is "ReferenceType". Ignored otherwise 
        ''' </summary>
        ''' <returns>dataClassType</returns>
        <JsonPropertyName("referenceClass")>
        Public Property referenceClass As dataClassType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>classifiersType</returns>
        <JsonPropertyName("classifiers")>
        Public Property classifiers As classifiersType
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>metadataCollectionType</returns>
        <JsonPropertyName("metadata")>
        Public Property metadata As metadataCollectionType
        ''' <summary>
        ''' Optional if domainType is "PrimitiveType". Ignored otherwise 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("units")>
        Public Property units As mandatoryString
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>string</returns>
        <JsonPropertyName("description")>
        Public Property description As String
        ''' <summary>
        ''' ### TODO: Add a description 
        ''' </summary>
        ''' <returns>mandatoryString</returns>
        <JsonPropertyName("label")>
        Public Property label As mandatoryString
    End Class
End Namespace