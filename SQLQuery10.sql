
CREATE TABLE SINGER(
ID_SINGER INT PRIMARY KEY IDENTITY(1,1),
NAME_SINGER NVARCHAR(50),
PICTURE_SINGER NVARCHAR(MAX),
)
CREATE TABLE GENRES(
ID_GENRE INT PRIMARY KEY IDENTITY(1,1),
NAME_GENRE NVARCHAR(50)
)
CREATE TABLE ALBUM(
ID_ALBUM INT PRIMARY KEY IDENTITY(1,1),
NAME_ALBUM NVARCHAR(50),
ID_SINGER INT,
ID_GENRE INT,
PICTURE_ALBUM NVARCHAR(MAX)
CONSTRAINT FK_ALBUMSINGER FOREIGN KEY(ID_SINGER) REFERENCES SINGER(ID_SINGER),
CONSTRAINT FK_ALBUMGENRE FOREIGN KEY(ID_GENRE) REFERENCES GENRES(ID_GENRE)
)
CREATE TABLE SONG(
ID_SONG INT PRIMARY KEY IDENTITY(1,1),
ID_SINGER INT,
ID_ALBUM INT,
ID_GENRE INT,
NAME_SONG NVARCHAR(50),
PATH_SONG NVARCHAR(MAX),
PICTURE_SONG NVARCHAR(MAX)
CONSTRAINT FK_SONGSINGER FOREIGN KEY(ID_SINGER) REFERENCES SINGER(ID_SINGER),
CONSTRAINT FK_SONGGENRE FOREIGN KEY(ID_GENRE) REFERENCES GENRES(ID_GENRE),
CONSTRAINT FK_SONGALBUM FOREIGN KEY(ID_ALBUM) REFERENCES ALBUM(ID_ALBUM)
)
--Them du lieu the loai
insert into genres(name_genre) values ('Pop');
insert into genres(name_genre) values ('Rock');
insert into genres(name_genre) values ('Jazz');
insert into genres(name_genre) values ('Opera');
insert into genres(name_genre) values ('Country');
insert into genres(name_genre) values ('RnB');
insert into genres(name_genre) values ('Dance');
insert into genres(name_genre) values ('Blues');
insert into genres(name_genre) values ('Ballad');
insert into genres(name_genre) values ('Accoustic');
insert into genres(name_genre) values ('Bolero');
--them du lieu ca si
insert into singer(name_singer)
values (N'Đàm Vĩnh Hưng');
insert into singer(name_singer)
values (N'Sơn Tùng M-TP');
insert into singer(name_singer)
values (N'Hà Anh Tuấn');
insert into singer(name_singer)
values (N'Bùi Anh Tuấn');
insert into singer(name_singer)
values (N'Phan Mạnh Quỳnh');
insert into singer(name_singer)
values (N'Lương Bích Hưu');
insert into singer(name_singer)
values (N'Uyên Linh');
insert into singer(name_singer)
values (N'Thu Minh');
--Them album Dam_Vinh_Hung
insert into album ( name_album, id_singer)
values ('Vol.1 - Tình ơi xin ngủ yên ','1');
insert into album ( name_album, id_singer)
values ('Vol.2 - Bình minh sẽ mang em đi ','1');
insert into album ( name_album, id_singer)
values ('Vol.3 - Một trái tim tình si ','1');
insert into album ( name_album, id_singer)
values ('Vol.5 - Giọt nước mắt cho đời ','1');
insert into album ( name_album, id_singer)
values ('Vol.6 - Hưng ','1');
insert into album ( name_album, id_singer)
values ('Vol.7 - Mr. Đàm ','1');
insert into album ( name_album, id_singer)
values ('Vol.9 - Giải thoát ','1');
insert into album ( name_album, id_singer)
values ('Vol.10 - Lạc mất em ','1');
--Them album Son_Tung
insert into album ( name_album, id_singer)
values ('Cafe sáng ','3');
insert into album ( name_album, id_singer)
values ('Sài Gòn Radio ','3');
insert into album ( name_album, id_singer)
values ('Cock-tail ','3');
insert into album ( name_album, id_singer)
values ('Lava ','3');
insert into album ( name_album, id_singer)
values ('Streets Rhythm ','3');
insert into album ( name_album, id_singer)
values ('Truyện ngắn ','3');
insert into album ( name_album, id_singer)
values ('Cuối ngày người đàn ông một mình ','3');
insert into album ( name_album, id_singer)
values ('Những vết thương lành ','3');
insert into album ( name_album, id_singer)
values ('Chân dung ','3');
insert into album ( name_album, id_singer)
values ('Biết tương tư ','3');



insert into album ( name_album, id_singer)
values ('Tết trong tâm hồn ','4');
insert into album ( name_album, id_singer)
values ('Nơi tình yêu trở lại ','4');
insert into album ( name_album, id_singer)
values ('Xin em ','4');
insert into album ( name_album, id_singer)
values ('Mùa đông tình yêu ','4');
insert into album ( name_album, id_singer)
values ('Cuộc xâm lăng của các chàng trai','4');
insert into album ( name_album, id_singer)
values ('Thu Nhớ','4');
insert into album ( name_album, id_singer)
values ('Hát gọi mùa xuân ','4');

insert into album ( name_album, id_singer)
values ('Người yêu cũ ','5');
insert into album ( name_album, id_singer)
values ('Anh ghét làm bạn em','5');
insert into album ( name_album, id_singer)
values ('Không quan trọng','5');
insert into album ( name_album, id_singer)
values ('Mất hy vọng','5');
insert into album ( name_album, id_singer)
values ('Vợ người ta','5');
insert into album ( name_album, id_singer)
values ('Khi người mình yêu khóc','5');
insert into album ( name_album, id_singer)
values ('Tri kỷ','5');


insert into album ( name_album, id_singer)
values ('Vol.2 Ây da Ây da','6');
insert into album ( name_album, id_singer)
values ('It is Not Over','6');
insert into album ( name_album, id_singer)
values ('Story of Time','6');
insert into album ( name_album, id_singer)
values ('Đứt từng đoạn ruột','6');
insert into album (name_album, id_singer)
values ('Mình cưới nhau nhé','6');


insert into album ( name_album, id_singer)
values ('Giấc mơ tôi','7');
insert into album ( name_album, id_singer)
values ('Ước sao ta chưa gặp nhau','7');
insert into album ( name_album, id_singer)
values ('Portrait','7');
insert into album ( name_album, id_singer)
values ('Chờ người nơi ấy','7');
insert into album ( name_album, id_singer)
values ('Tình khúc một thời 1','7');

--album singer Thu Minh
insert into album ( name_album, id_singer)
values ('Ước mơ','8');
insert into album ( name_album, id_singer)
values ('Lời cuối','8');
insert into album ( name_album, id_singer)
values ('Nếu như','8');
insert into album ( name_album, id_singer)
values ('Tình em','8');
insert into album ( name_album, id_singer)
values ('Thiên đàng','8');
insert into album ( name_album, id_singer)
values ('I Do','8');
insert into album ( name_album, id_singer)
values ('Giác quan thứ 6','8');
insert into album ( name_album, id_singer)
values ('Body Language','8');
insert into album ( name_album, id_singer)
values ('The Best of Thu Minh','8');
insert into album ( name_album, id_singer)
values ('Album Hit Remix','8');
create table USERS(
ID_USER INT PRIMARY KEY IDENTITY(1,1),
NAME_USER NVARCHAR(50),
PASSWORD VARCHAR(50),
EMAIL VARCHAR(100),
AVARTAR NVARCHAR(MAX)
)
insert into users ( name_user, password, email, decentralization )
values('admin','admin','admin@gmail.com',1);
insert into users ( name_user, password, email, decentralization)
values('Khanh','Khanh','Khanh@gmail.com',0);
insert into users ( name_user, password, email, decentralization)
values(N'Tai','Tai','Tai@gmail.com',0);
insert into users ( name_user, password, email, decentralization )
values(N'Hiep','Hiep','Hiep@gmail.com',0);
insert into users ( name_user, password, email, decentralization )
values(N'Nhan','Nhan','Nhan@gmail.com',0);
insert into users ( name_user, password, email, decentralization )
values(N'Duoc','Duoc','Duoc@gmail.com',0);
insert into users ( name_user, password, email, decentralization )
values(N'Hoc','Hoc','Hoc@gmail.com',0);


ALTER TABLE USERS ADD decentralization INT