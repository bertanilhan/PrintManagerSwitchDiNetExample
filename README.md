Request'deki parametreler göre instance factory dinamik olarak instance oluşturur.

http://localhost:XXXXX/Print                           => BasePrintManager'dan örnek oluşturur.
http://localhost:XXXXX/Print?Device=Xerox              => XeroxPrintManager'dan örnek oluşturur.
http://localhost:XXXXX/Print?Device=KonicaMinolta      => KonicaMinoltaManager'dan örnek oluşturur.
