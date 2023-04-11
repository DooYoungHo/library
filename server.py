import socket
import socketserver
import threading
from datetime import datetime, timedelta

import pymysql

from selenium import webdriver
from selenium.webdriver.common.keys import *
from selenium.webdriver.common.by import By
from selenium.webdriver.support.select import Select
import time

import requests
from io import BytesIO
from PIL import ImageTk , Image
import os
import base64
from array import array
import sys

# elem.send_keys(Keys.RETURN)
# elem = driver.find_element(by="id",value="query")
# elem.send_keys("대전날씨")
# elem.send_keys(Keys.RETURN)  #엔터 기능

#192.168.35.193ipㅑㅔ
HOST = '192.168.0.53' # 서버의 ip를 열음. (이 서버의 ip로 클라이언트가 접속을 해야 한다), 그전에 ping을 먼저 확인하도록.
PORT = 9599				 # 포트번호 (같아야 함)
lock = threading.Lock()  # syncronized 동기화 진행하는 스레드 생성

con = pymysql.connect(host="localhost", user='root', password='0000', db='library_db', charset='utf8')
cur = con.cursor()

listy = []
tup = ()
login_check = ""

def sql_data(text) :
    s = f"SELECT * FROM library_db.{text}"
    cur.execute(s)
    d = cur.fetchall()
    return d

class UserManager:

    con = pymysql.connect(host="localhost", user='root', password='0000', db='library_db', charset='utf8')
    cur = con.cursor()
    sql_table_list = ['essay','fiction','travel','IT','child','all_book']

    def __init__(self):
        self.users = {}  # 사용자의 등록 정보를 담을 사전 {사용자 이름:(소켓,주소),...}
        # selenium
        self.img_driver = None
        self.book_driver = None
        self.elem = None
        self.choice_book_text = None
        self.img = None
        self.ranking_driver = None
        self.res = None
        self.r_img = None
        # SQL
        self.reset_data = None
        self.data = None
        self.ok = None
        self._hope_book_name = None
        self._rental_book_name = None
        self._rental_count = None
        self._rental_date = None
        self.return_book = None
        self.return_date = None
        self.rental_count = None
        self.img_data = None
        self.book_img_ranking_list = ''
        self.book_img_ranking_one_list = ''
        # 이게 맞는지는 모르겠다
        self.data1 = None
        self.data2 = None
        self.data3 = None
        self.data4 = None
        self.data5 = None
        self.data6 = None
        # 유저 대여 목록
        self.user_rental = None

    def Book_img(self,text):                  # 책 이미지 저장
        options = webdriver.ChromeOptions()
        #options.headless = True
        options.add_argument('window-size=1920x1080')
        options.add_argument('disable-gpu')

        self.img_driver = webdriver.Chrome('chromedriver',options=options)
        url = 'https://www.kyobobook.co.kr/'
        self.img_driver.get(url)

        elem = self.img_driver.find_element(by="id", value="searchKeyword")
        elem.send_keys(text)
        elem.send_keys(Keys.RETURN)  #엔터 기능
        img = self.img_driver.find_element(By.XPATH,'//*[@id="shopData_list"]/ul/li[1]/div[1]/div[1]/a/span/img')

        # request.get 요청
        res = requests.get(img.get_attribute('src'))

        # Img open
        img = Image.open(BytesIO(res.content))
        r_img = img.resize((200, 250))
        r_img.save(f'{text}.jpg')

        img_open = open(f'{text}.jpg','rb')
        print(img_open)
        binary_img = base64.b64encode(img_open.read())
        img_data = binary_img.decode('UTF-8')

        return img_data

    def SQL_All_Data(self):         # 모든 책 정보
        self.data = "SELECT * FROM library_db.all_book"
        UserManager.cur.execute(self.data)
        self.data = UserManager.cur.fetchall()
        return self.data

    def SQL_user_data(self):         # 회원 정보 확인
        self.data = "select * from library_db.rental_book"
        UserManager.cur.execute(self.data)
        self.data = UserManager.cur.fetchall()
        return self.data

    def SQL_one_table(self,text):       # 한 테이블 확인하기
        self.data = f"select * from library_db.{text}"
        UserManager.cur.execute(self.data)
        self.data = UserManager.cur.fetchall()
        return self.data

    def SQL_user_rental(self,user,tuple):    # 유저 대여 확인
        f = ''
        for i in tuple :
            if i[0] == user :
                if i[2] == None :
                    return '1' + '♭' + '1' + '♭' + '1' + '♭' + '1' + '♭' + '1' + '♭' + '1' + '♭' + '1' + '♭' + '1' + '♭' + '1' + '♭'
                elif '■' in i[2] :
                    book_name = i[2].split('■')
                    book_date = i[4].split('■')
                    for i in range(len(book_name)) :
                        day = datetime.strptime(book_date[i],'%Y-%m-%d')
                        few_day = day+timedelta(days=15)
                        s = day.strftime('%Y-%m-%d')
                        d = few_day.strftime('%Y-%m-%d')
                        f += book_name[i] + '♭' + s + '♭' + d + '♭'
                    if f.count('♭') == 6 :
                        f += '1'+'♭'+'1'+'♭'+'1'+'♭'
                        return f
                    else :
                        return f
                else :
                    book_name = i[2]
                    book_date = i[4]
                    day = datetime.strptime(book_date,'%Y-%m-%d')
                    few_day = day+timedelta(days=15)
                    s = day.strftime('%Y-%m-%d')
                    d = few_day.strftime('%Y-%m-%d')
                    return book_name+'♭'+s+'♭'+d+'♭'+'1'+'♭'+'1'+'♭'+'1'+'♭'+'1'+'♭'+'1'+'♭'+'1'+'♭'

    def SQL_hope_list(self,id,text):          # 찜 목록 업데이트
        try :
            for i in self.SQL_user_data() :
                if i[0] == id :
                    self._hope_book_name = i[1]

            if self._hope_book_name == None :
                self._hope_book_name = text
            else :
                if text in self._hope_book_name :
                    pass
                else :
                    self._hope_book_name += "♡" + text

            self.data = "UPDATE rental_book SET rental_hope=%s WHERE rental_book_ID=%s"
            self.reset_data = (self._hope_book_name,id)
            self.cur.execute(self.data,self.reset_data)
            self.con.commit()
        except Exception as e :
            print(e)

    def SQL_return(self,id,text):      # 반납하기
        book_name = []
        book_date = []
        for i in self.SQL_user_data() :
            if i[0] == id :
                book_name = i[2].split('■')
                self.rental_count = i[3] - 1
                book_date = i[4].split('■')
        for i in range(len(book_name)) :
            if book_name[i] == text :
                del book_name[i]
                del book_date[i]
                break
        print('--삭제 후 입니다--')
        print(book_name)
        if len(book_name) == 1:
            self.return_book = book_name[0]
            self.return_date = book_date[0]
        elif len(book_name) == 2:
            self.return_book = book_name[0]+'■'+book_name[1]
            self.return_date = book_date[0]+'■'+book_date[1]
        else :
            self.return_book = None
            self.return_date = None
            self.rental_count = 0
        print('---최종본---')
        print(self.return_book)
        print(self.return_date)
        print(self.rental_count)

        self.data = "UPDATE rental_book SET rental_book_name=%s,rental_book_rental=%s,rental_book_date=%s WHERE rental_book_ID=%s"
        self.reset_data = (self.return_book,self.rental_count,self.return_date,id)
        self.cur.execute(self.data,self.reset_data)
        self.con.commit()

    def SQL_rental_list(self,id,text):                  # 대여 시스템
        rental_info = []
        today = datetime.today()
        today = today.strftime('%Y-%m-%d')
        try :
            for i in self.SQL_user_data() :
                if i[2] is not None :
                    if i[2] not in rental_info :
                        rental_info += i[2].split('■')
                else :
                    pass
            if text in rental_info :
                return "■대여중"
            else :
                for i in self.SQL_user_data() :
                    if i[0] == id :
                        self._rental_book_name = i[2]
                        self._rental_count = i[3]
                        self._rental_date = i[4]
                if self._rental_count >= 3 :
                    return "■최대 대여 횟수가 초과했습니다"
                elif self._rental_count <= 3 :
                    self._rental_count += 1
                if self._rental_book_name == None :
                    self._rental_book_name = text
                else :
                    self._rental_book_name += "■"+text
                if self._rental_date == None :
                    self._rental_date = str(today)
                else :
                    self._rental_date += "■"+str(today)

                self.data = "UPDATE rental_book SET rental_book_name=%s,rental_book_rental=%s,rental_book_date=%s WHERE rental_book_ID=%s"
                self.reset_data = (self._rental_book_name,self._rental_count,self._rental_date,id)
                self.cur.execute(self.data,self.reset_data)
                self.con.commit()
                return "■대여가능"
        except Exception as e :
            print(e)

    def count_update(self,title,text):        # 카운트 업데이트 해주는 함수인데 이게 맞을까
        for i in self.SQL_one_table(title) :
            if self._rental_count is not None :
                if self._rental_count >= 3 :
                    return
            if text == i[1] :
                num = i[5]
                num += 1
                self.data = f"UPDATE {title} SET {title}_rental_count = %s WHERE {title}_name =%s"
                self.reset_data = (num,text)
                self.cur.execute(self.data,self.reset_data)
                self.con.commit()

    def SQL_rental_count(self,text):      # 대여시 전체 책들 찾고 업데이트
        for i in UserManager.sql_table_list :
            self.count_update(i,text)

    def Book_info(self,text):           # 책 상세정보
        options = webdriver.ChromeOptions()
        #options.headless = True
        options.add_argument('window-size=1920x1080')
        options.add_argument('disable-gpu')

        self.book_driver  = webdriver.Chrome('chromedriver',options=options)
        url = "https://www.ypbooks.co.kr/kor_index.yp"
        self.book_driver.get(url)

        self.elem = self.book_driver.find_element(by="id",value='t_query')
        self.elem.send_keys(text)
        self.elem.send_keys(Keys.RETURN)
        self.choice_book_text = self.book_driver.find_element(By.CLASS_NAME,"info02")
        return self.choice_book_text.text

    def download_imag(self, list):     # 랭킹 다운로드 이미지
        for i in range(len((list))):
            options = webdriver.ChromeOptions()
            #options.headless = True
            options.add_argument('window-size=1920x1080')
            options.add_argument('disable-gpu')

            self.ranking_driver = webdriver.Chrome('chromedriver',options=options)
            url = "https://www.kyobobook.co.kr/"
            self.ranking_driver.get(url)

            self.elem = self.ranking_driver.find_element(by='id',value='searchKeyword')
            self.elem.send_keys(list[i])
            self.elem.send_keys(Keys.RETURN)
            self.img = self.ranking_driver.find_element(By.XPATH, '//*[@id="shopData_list"]/ul/li[1]/div[1]/div[1]/a/span/img')

            self.res = requests.get(self.img.get_attribute('src'))

            self.img = Image.open(BytesIO(self.res.content))
            self.r_img = self.img.resize((150,200))
            i += 1
            self.r_img.save(f'C:\\all_ranking\\{i}.jpg')

            img_open = open(f'C:\\all_ranking\\{i}.jpg', 'rb')
            binary_img = base64.b64encode(img_open.read())
            img_data = binary_img.decode('utf-8')
            self.book_img_ranking_list += img_data + '♧'
            print(f'{i}번째입니다')
        return self.book_img_ranking_list

    def one_img_download(self,list,text):
        for i in range(len((list))):
            options = webdriver.ChromeOptions()
            #options.headless = True
            options.add_argument('window-size=1920x1080')
            options.add_argument('disable-gpu')

            self.ranking_driver = webdriver.Chrome('chromedriver',options=options)
            url = "https://www.kyobobook.co.kr/"
            self.ranking_driver.get(url)

            self.elem = self.ranking_driver.find_element(by='id',value='searchKeyword')
            self.elem.send_keys(list[i])
            self.elem.send_keys(Keys.RETURN)
            self.img = self.ranking_driver.find_element(By.XPATH, '//*[@id="shopData_list"]/ul/li[1]/div[1]/div[1]/a/span/img')

            self.res = requests.get(self.img.get_attribute('src'))

            self.img = Image.open(BytesIO(self.res.content))
            self.r_img = self.img.resize((225,320))
            i += 1
            self.r_img.save(f'C:\\{text}_img\\{i}.jpg')

            img_open = open(f'C:\\{text}_img\\{i}.jpg', 'rb')
            binary_img = base64.b64encode(img_open.read())
            self.img_data = binary_img.decode('utf-8')
            print(f'{i}번째입니다')
        self.book_img_ranking_one_list = self.img_data + '♧'
        print(self.book_img_ranking_one_list)

        return self.book_img_ranking_one_list

    def Top_6(self,text):
        self.data = f"select * from library_db.{text} order by {text}_rental_count DESC limit 6"
        UserManager.cur.execute(self.data)
        self.data = UserManager.cur.fetchall()
        return self.data

    def Top_1(self,text):
        self.data = f"select * from library_db.{text} order by {text}_rental_count DESC limit 1"
        UserManager.cur.execute(self.data)
        self.data = UserManager.cur.fetchall()
        return self.data

    def addUser(self, username, conn, addr):  # 사용자 ID를 self.users에 추가하는 함수
        if username in self.users:  # 이미 등록된 사용자라면
            conn.send('이미 등록된 사용자입니다.\n'.encode())
            return None

        # 새로운 사용자를 등록함
        lock.acquire()  # 스레드 동기화를 막기위한 락
        self.users[username] = (conn, addr)
        lock.release()  # 업데이트 후 락 해제

        return username

    def removeUser(self, username):  # 사용자를 제거하는 함수
        if username not in self.users:
            return

        lock.acquire()
        del self.users[username]
        lock.release()

    def messageHandler(self, username, msg):  # 전송한 msg를 처리하는 부분 (그럼 여기가 버튼에 대한 값이 뭔가가 들어와야지 않을까?)

        book_info = ""
        user_info = username.split(" ")
        list_data = []
        all_ranking = ""
        pp =''

        print("------체크입니다------")
        print(msg)
        print(user_info)

        if "■" in msg.strip() :
            self.SQL_rental_count(msg.strip()[1:])
            self.sendMessage(self.SQL_rental_list(user_info[0],msg.strip()[1:]))
            return

        if '♭' == msg.strip() :
            self.sendMessage(self.SQL_user_rental(user_info[0],self.SQL_user_data()))
            return

        if '〃' in msg.strip() :
            self.SQL_return(user_info[0],msg[2:])
            return

        if msg.strip() == "R_A":
            for i in self.Top_6('all_book'):
                list_data.append(i[1])
            pp += self.download_imag(list_data)
            for i in list_data:
                all_ranking += i + '○'
            print('-모든 책 완료-')
            list_data = []
            for i in self.Top_1('essay'):
                list_data.append(i[1])
            pp += self.one_img_download(list_data, 'essay')
            print('-에쎄이 완료-')
            list_data = []
            for i in self.Top_1('fiction'):
                list_data.append(i[1])
            pp += self.one_img_download(list_data, 'fiction')
            print('-픽션 완료-')
            list_data = []
            for i in self.Top_1('travel'):
                list_data.append(i[1])
            pp += self.one_img_download(list_data, 'travel')
            list_data = []
            print('-여행 완료-')
            for i in self.Top_1('IT'):
                list_data.append(i[1])
            pp += self.one_img_download(list_data, 'IT')
            list_data = []
            print('-IT-완료')
            for i in self.Top_1('child'):
                list_data.append(i[1])
            pp += self.one_img_download(list_data, 'child')
            self.sendMessage(pp)
            print('-어린이 완료-')
            self.sendMessage(all_ranking)
            return

        if msg.strip() == "R_E" :
            for i in self.Top_1('essay') :
                list_data.append(i[1])
            for i in list_data :
                all_ranking += i + '○' + 'essay'
            self.sendMessage(all_ranking)
            return

        if msg.strip() == 'R_F' :
            for i in self.Top_1('fiction') :
                list_data.append(i[1])
            for i in list_data :
                all_ranking += i + '○' + 'fiction'
            self.sendMessage(all_ranking)
            return

        if msg.strip() == "R_T" :
            for i in self.Top_1('travel') :
                list_data.append(i[1])
            for i in list_data :
                all_ranking += i + '○' + 'travel'
            self.sendMessage(all_ranking)
            return

        if msg.strip() == "R_I" :
            for i in self.Top_1('IT') :
                list_data.append(i[1])
            for i in list_data :
                all_ranking += i + '○' + 'IT'
            self.sendMessage(all_ranking)
            return

        if msg.strip() == "R_C" :
            for i in self.Top_1('child') :
                list_data.append(i[1])
            for i in list_data :
                all_ranking += i + '○' + 'child'
            self.sendMessage(all_ranking)
            return

        if msg.strip() == "(소설" :
            for i in sql_data("fiction") :
                book_info += i[1]+"*"
            self.sendMessage(book_info)
            return
        elif msg.strip() == "(에쎄이" :
            for i in sql_data("essay") :
                book_info += i[1]+"*"
            self.sendMessage(book_info)
            return
        elif msg.strip() == "(여행" :
            for i in sql_data("travel") :
                book_info += i[1]+"*"
            self.sendMessage(book_info)
            return
        elif "(컴퓨터" in msg.strip() :
            for i in sql_data("IT") :
                book_info += i[1]+"*"
            self.sendMessage(book_info)
            return
        elif msg.strip() == "(어린이" :
            for i in sql_data("child") :
                book_info += i[1]+"*"
            self.sendMessage(book_info)
            return
        if '/' in msg.strip() :
            for i in self.SQL_All_Data() :
                if msg.strip()[1:] == i[1] :
                    self.ok = f"{i[1]}∥{i[2]}∥{i[3]}∥{i[4]}"
            self.sendMessage(self.ok+'∥'+self.Book_info(msg[1:])+'∥'+self.Book_img(msg[1:]))
            self.book_driver.quit()
            self.img_driver.quit()
            return
        if "@" in msg.strip() :
            list_id = msg.strip().split("@")
            for i in self.SQL_user_data() :
                if i[0] == list_id[0] :
                    self.SQL_hope_list(i[0],list_id[2])
            for i in self.SQL_user_data() :
                if i[0] == list_id[0] :
                    self.sendMessage('♡'+i[1])
                    return

        if msg.strip() == "⊥나가기" :      #이 기능은 있어야되긴함
            self.sendMessage('⊥나가기')
            self.removeUser(username)
            return -1

    def sendMessageToAll(self, msg):           # 서버가 모든 이용자들에게 무언가를 뿌리는 곳
        for conn, addr in self.users.values():
            conn.send(msg.encode())

    def sendMessage(self, text):          # 서버가 이용하는 사람들에게 보내는거 ??
        global tup
        for conn, addr in self.users.values():
            if addr == tup:
                conn.send(text.encode())

class MyTcpHandler(socketserver.BaseRequestHandler):      # 슈퍼 클래스 ? ( 즉 이게 그럼 부모 클래스다 ? )

    userman = UserManager()
    con = pymysql.connect(host="localhost", user='root', password='0000', db='library_db', charset='utf8')
    cursor = con.cursor()

    def handle(self):  # 클라이언트가 접속시 클라이언트 주소 출력

        global username

        print('[%s] 연결' % self.client_address[0])

        try:
            username = self.registerUsername()
            msg = self.request.recv(1024)
            while msg:
                if self.userman.messageHandler(username, msg.decode()) == -1:
                    self.request.close()
                    break
                msg = self.request.recv(1024)
        except Exception as e:
            print(e)
        print('[%s] 접속종료' % self.client_address[0])
        self.userman.removeUser(username)
    def registerUsername(self):
        global listx , tup , login_check
        while True:
            username = self.request.recv(1024)
            username = username.decode().strip()
            listy = username.split()
            listt = username.split()
            tup = self.client_address
            if '회' in listy[0] :
                for i in sql_data('member') :
                    if i[2] == listy[2] and i[3] == listy[3] :
                        self.request.send("Exist".encode('utf-8'))
                        return self.registerUsername()
                    else :
                        update_sql = 'insert into member values(%s,%s, %s, %s)'
                        sql_val = (None, listy[1], listy[2], listy[3])
                        MyTcpHandler.cursor.execute(update_sql,sql_val)
                        MyTcpHandler.con.commit()
                        update2_sql = 'insert into rental_book values(%s,%s, %s, %s, %s)'
                        sql2_val = (listy[2],None,None,0,None)
                        MyTcpHandler.cursor.execute(update2_sql,sql2_val)
                        MyTcpHandler.con.commit()
                        MyTcpHandler.con.close()
                        self.request.send('Create'.encode('utf-8'))
                        for i in self.SQL_join_update() :
                            print(i)
                        return self.registerUsername()
            else :
                for i in self.SQL_join_update() :
                    print(i)
                    if i[2] == listt[0] and i[3] == listt[1] :
                        login_check = "성공"
                if login_check == "성공" :
                    if self.userman.addUser(username, self.request, self.client_address):
                        self.request.send("Complete".encode('utf-8'))
                        return username  # 리스트에 있는 아이디가 들어갈 예정
                else:
                    self.request.send("Error".encode())
                    return self.registerUsername()

    def SQL_join_update(self):
        con = pymysql.connect(host="localhost", user='root', password='0000', db='library_db', charset='utf8')
        cursor = con.cursor()
        sql = 'select * from library_db.member'
        cursor.execute(sql)
        d = cursor.fetchall()
        return d

class ChatingServer(socketserver.ThreadingMixIn, socketserver.TCPServer):    # 이걸 상속받는게 아닌가??
    pass

def runServer():
    print('채팅 서버를 시작합니다.')
    try:
        server = ChatingServer((HOST, PORT), MyTcpHandler)    # TCPServer (address => 튜플 형태로 (IP, PORT)순 , RequestHandlerclass) 자리에 들어간 것
        server.serve_forever()
    except KeyboardInterrupt:
        print('채팅 서버를 종료합니다.')
        server.shutdown()
        server.server_close()

runServer()

con.close()
cccc = UserManager()
cccc.con.close()