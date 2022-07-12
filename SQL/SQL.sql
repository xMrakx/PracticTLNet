use [CD Shop]

--CRUD
update [Worker]
set phone_number = '+79877451632'
where name = '����' and surename = '������'

delete from [Worker]
where name = '����' and surename = '������'

--GroupBy
select artist, count(id_cd) as album_count from [CD]
group by artist

--GroupBy + having
select id_worker, count(id_purchase) as purchase_count from [Purchase]
group by id_worker
having count(id_purchase) > 2

--Join
select name, count(Purchase.id_purchase) as purchase_count from [CD]
right join [Purchase] on Purchase.id_cd = [CD].id_cd
group by name
