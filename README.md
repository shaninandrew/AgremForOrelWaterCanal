# AgremForOrelWaterCanal
Программа управления договорами в ОрелВодоканал

    1 База данных MSSQL

    2 Приложение на C#


1 База данных

1.1 Представлена таблицами:

    Договоров (Agrements),
        * Основные поля: Номер и дата, сумма по услуге, сумма НДС
        
    Клиентов (Clients) /связка Agreements - список клиентов по договору
        * Основные поля: ID договора, Тип договора (1-физ, 2 юр лицо), ID клиента в соответствующей таблице
                Физическиех лиц (Privates) /связка Agreements + Clients
                Юридических лиц (Entity) /связка Agreements + Clients
                
    Услуг оказываемые по договору из прайс листа (ServiceForAgreements ) Agreements + PriceList
        * Основные поля: ID SFA,  ID договора, ID услуги по прайсу, Количество услуг, Дата начала и Дата конца действия цены на услугу
        
    Услуги по прайслисту (PriceList) соединятся через ServiceForAgreements с  Договором
        * Основные поля: ID договора, Название услуги, Цена, НДС Ставка
    

1.2 Имеет функции:
    
    Добавления нового договора. В таблицу Договоров дабавляется запись, создаетсся новая связка по услугам на прайслист
        * Параметры: дата договора (сегодня) @Date
            Agreemnts INSERT     ServiceForAgreements INSERT 
            INSERT INTO  Agreements (Date) VALUES (@Date)
        
    
    Установки даты договора. При изменении даты в договоре Agreements передергивается связка с прайс листом, т.к. цены будут зависить
    от даты действия цен в прайсе
        * Параметры: @Date, @ArgeeID
            --ID SFA возвращает новые строки в ServiceForAgreements
            INSERT Into ServiceForAgreements ( ID PriceList , ID договора ) 
                OUTPUT  INSERTED.
                SELECT  pr.ID PriceList,  @ArgeeID FROM PriceList pr WHERE   @DATE between pr.Дата начала  and  pr.Дата конца действия
            
    

    Связки Договора и Клиентов. 
    Параметры ID договора, ID клиента, Тип клиента

    
    
    
