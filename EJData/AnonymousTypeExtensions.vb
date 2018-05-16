Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Module AnonymousTypeExtensions

    <Extension()>
    Public Function ToType(ByVal obj As Object, T As Type) As Object  '<T>(this object obj, T type)
        'create instance of T type object
        Dim tmp = Activator.CreateInstance(Type.GetType(T.ToString()))

        'loop through the properties of the object you want to covert          
        For Each pi As PropertyInfo In obj.GetType().GetProperties()
            Try

                'get the value of property And try 
                'to assign it to the property of T type object
                tmp.GetType().GetProperty(pi.Name).SetValue(tmp,
                                  pi.GetValue(obj, Nothing), Nothing)

            Catch
            End Try
        Next

        'return the T type object         
        Return tmp
    End Function

    <Extension()>
    Public Function PToNonAnonymousList(Of Tinput, Toutput)(ByVal lst As List(Of Tinput), tp As Type) As List(Of Toutput)
        'define system Type representing List of objects of T type
        Dim genericType = GetType(List(Of Tinput)).MakeGenericType(tp)

        'create an object instance of defined type
        Dim l = Activator.CreateInstance(genericType)

        'get method Add from from the list
        Dim addMethod As MethodInfo = l.GetType().GetMethod("Add")

        'loop through the calling list
        For Each item As Tinput In lst


            'convert each object of the list into T object 
            'by calling extension ToType<T>()
            'Add this object to newly created list
            addMethod.Invoke(l, New [Object]() {item.ToType(tp)})
        Next

        'return List of T objects
        Return l
    End Function
End Module
