# AgremForOrelWaterCanal
Программа управления договорами в ОрелВодоканал

1 База данных MSSQL

2 Приложение на C#


1 База данных

Предстьавлена таблицами:

    Договоров (Agrements),
    Клиентов (Clients) /связка Agreements - список клиентов по договору
        Физическиех лиц (Privates) /связка Agreements + Clients
        Юридических лиц (Entity) /связка Agreements + Clients
    Услуг оказываемые по договору из прайс листа (ServiceForAgreements ) Agreements + PriceList
    Услуги по прайслисту (PriceList) через ServiceForAgreements соединено с  
    
