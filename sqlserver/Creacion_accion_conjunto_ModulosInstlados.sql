SELECT * FROM ERPADMIN.ACCION 


INSERT INTO ERPL360.ERPL360.MODULO_INSTALADO(CONJUNTO,ACCION)
SELECT CONJUNTO,ACCION FROM ERPADMIN.MODULO_INSTALADO where CONJUNTO='CINCOH'

SELECT * FROM ERPADMIN.CONJUNTO where CONJUNTO='CINCOH'

SELECT CONJUNTO,NOMBRE FROM erpadmin.CONJUNTO