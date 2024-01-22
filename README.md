# AgreementsForOrelWaterCanal
Программа управления договорами в ОрелВодоканал

    1 База данных MSSQL

    2 Приложение на C#


1 База данных

1.1 Представлена таблицами:

    Договоров (Agrements),
        * Основные поля: ID документа,  Номер и дата, сумма по услуге, сумма НДС
        
    Клиентов (Clients) /связка Agreements - список клиентов по договору
        * Основные поля: ID договора, Тип договора (1-физ, 2 юр лицо), ID клиента в соответствующей таблице
                Физическиех лиц (Privates) /связка Agreements + Clients
                Юридических лиц (Entity) /связка Agreements + Clients
     
    Физическиех лиц (Privates)
        * Основные поля: ID, ФИО, Паспорт, Адрес, Телефон и т.п.

    Юридических лиц (Entity)
        * Основные поля: ID, Название, ИНН, ОГРН, Адрес, Телефон и т.п.

    Услуг оказываемые по договору из прайс листа (ServiceForAgreements ) Agreements + PriceList
        * Основные поля: ID SFA,  ID договора, ID услуги по прайсу, Количество услуг, Дата начала и Дата конца действия цены на услугу
        
    Услуги по прайслисту (PriceList) соединятся через ServiceForAgreements с  Договором
        * Основные поля: ID прайса, Название услуги, Цена, НДС Ставка
    

1.2 Имеет функции:
    
    1 Добавления нового договора. В таблицу Договоров дабавляется запись, создаетсся новая связка по услугам на прайслист
        * Параметры: дата договора (сегодня) @Date
            Agreemnts INSERT     ServiceForAgreements INSERT 
            INSERT INTO  Agreements (Date) VALUES (@Date)

        
    2 Установки даты договора. При изменении даты в договоре Agreements передергивается связка с прайс листом, т.к. цены будут зависить
    от даты действия цен в прайсе
        * Параметры: @Date, @ArgeeID
            --ID SFA возвращает новые строки в ServiceForAgreements
            INSERT Into ServiceForAgreements ( ID PriceList , ID договора, Количество услуг ) 
                OUTPUT  INSERTED.ID SFA
                SELECT  pr.ID PriceList,  @ArgeeID, 1 
                FROM PriceList pr 
                WHERE   @DATE between pr.Дата начала  and  pr.Дата конца действия
            

    3 Связки Договора и Клиентов c новым клиентом Clients.
        * Параметры: ID договора (@ID Agr),  Тип клиента (@Type)
        INSERT INTO  Clients (
            IF @Type=1
                INSERT INTO Privates OUTPUT.INSERTED ID_клиента
                    (Фио) VALUES ('Новый ф/л')
            ELSE  
                INSERT INTO Entity 
                OUTPUT.INSERTED ID_клиента 
                    (Название ) VALUES ('Новое юр лицо')

    4 Связки Договора и Клиентов с существующим клиентом Clients.
         * Параметры: ID договора (@ID Agr),  ID Клиента (@IDClient)
             UPDATE  Clients SET 
                   ID клиента  = @IDClient
                  WHERE ID договора = @ID Agr 
    
    5 Расчет стоимости услуг по договору возврат суммы и ндс с Округлением   
        * Параметр ID договора (@ID Agr)
            SELECT ROUND( (sfa.Количество услуг *  pl.Цена),2) sum_ , ROUND( (sfa.НДС Ставка * sum_) ,2)  vat
            FROM  ServiceForAgreements sfa 
            INNER JOIN  PriceList AS pl  ON (pl.ID прайса = sfa.ID услуги по прайсу)
            INNER JOIN  Agrements AS agr  ON (agr.ID договора = sfa.ID договора)
                WHERE agr.ID договора = @ID Agr
                
            
    
    
    
