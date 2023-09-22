/* Tugas Query
Buatlah dalam 1 query untuk mendapatkan duplicate data berdasarkan 1 field.
*/

SELECT field_name, COUNT(*) AS Count FROM Table_name
GROUP BY field_name
HAVING COUNT(*)>1;


/* Tugas Query
Buatlah dalam 1 query antara 2 table (misal TableA dan TableB), untuk menemukan data yang missing dari TableB, berdasarkan 1 field.
*/

SELECT a.field_name, a.value FROM table_a a
LEFT JOIN table_b b ON a.field_name = b.field_name
WHERE b.field_name IS NULL