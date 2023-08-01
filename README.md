# ELK (file logs+syslog)

Example project that accamulates logs from filesystem and syslog.

Logs example:

```log
2023/07/18 14:51:12,ERROR,QBNJJ,Service1Controller,DESKTOP-LSEVLDM,,[Params] project=Service1, message=Error message from service 1, param1=param1, param2=param2, [/Params][Exception] ExceptionType_1=ApiException,ExceptionLastFunction_1=MoveNext, ExeptionMessage_1={Could not deserialize the response body stream as Result.$CR$$CR$Status: 400$CR$Response: $CR$} ExceptionType_2=JsonSerializationException,ExceptionLastFunction_2=EnsureType ExeptionMessage_2={Error converting value "Param" to type Type1. Path  line 1 position 51.}  ExceptionType_3=ArgumentException ExceptionLastFunction_3=EnsureTypeAssignable, ExeptionMessage_3={Could not cast or convert from System.String to Type1.}, [/Exception]
```

```log
2023/07/18 14:51:12,ERROR,QBNJJ,Service1Controller,DESKTOP-LSEVLDM, project=Service1, message=Error message from service 1, param1=param1, param2=param2, ExceptionType_1=ApiException,ExceptionLastFunction_1=MoveNext, ExeptionMessage_1={Could not deserialize the response body stream as Result.$CR$$CR$Status: 400$CR$Response: $CR$} ExceptionType_2=JsonSerializationException,ExceptionLastFunction_2=EnsureType ExeptionMessage_2={Error converting value "Param" to type Type1. Path  line 1 position 51.}  ExceptionType_3=ArgumentException ExceptionLastFunction_3=EnsureTypeAssignable, ExeptionMessage_3={Could not cast or convert from System.String to Type1.}, LoggerVersion=V3
```
