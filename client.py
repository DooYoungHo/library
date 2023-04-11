import io
import socket
import sys
import textwrap
import time
import tkinter
import tkinter.messagebox
from _thread import *
import threading
from tkinter import *
from time import sleep
import tkinter.font as tkFont
import tkinter.messagebox as msgbox
from PIL import ImageTk , Image
import tkinter.font as font
import tkinter.ttk as ttk
import pymysql
from selenium import webdriver
from selenium.webdriver.common.keys import *
from selenium.webdriver.common.by import By
from selenium.webdriver.support.select import Select
import PyInstaller
import os
import base64

def make_folder() :
    if os.path.exists("C:\\all_ranking"):
        pass
    else:
        os.mkdir("C:\\all_ranking")

    if os.path.exists("C:\\essay_img") :
        pass
    else :
        os.mkdir("C:\\essay_img")

    if os.path.exists("C:\\travel_img") :
        pass
    else :
        os.mkdir("C:\\travel_img")

    if os.path.exists("C:\\fiction_img") :
        pass
    else :
        os.mkdir("C:\\fiction_img")

    if os.path.exists("C:\\IT_img") :
        pass
    else :
        os.mkdir("C:\\IT_img")

    if os.path.exists("C:\\child_img") :
        pass
    else :
        os.mkdir("C:\\child_img")

make_folder()

class UserClient :

    HOST = '192.168.0.53'
    PORT = 9599

    id_data = ''
    pw_data = ''

    combo_data = ''

    combo_list = ['에쎄이','소설','여행','컴퓨터/프로그래밍','어린이']

    book_data_list = []

    def __init__(self):
        # 서버 연결
        self.conn_soc = None

        # 리스트박스
        self.ind = None
        self.info = None
        self.data = None
        self.result = None

        # 로그인 화면
        self.window = None
        self.id_entry = None
        self.pw_entry = None
        self.btn1 = None
        self.canvas = None
        self.photo = None
        self.photo2 = None
        self.photo3 = None
        self.photo4 = None
        self.photo5 = None
        self.photo6 = None
        self.photo7 = None
        self.photo8 = None
        self.photo9 = None
        self.photo10 = None
        self.photo11 = None
        self.photo12 = None

        self.photo13 = None
        self.photo14 = None
        self.photo15 = None
        self.photo16 = None
        self.photo17 = None
        self.photo18 = None

        # 회원가입 화면
        self.joinWindow = None
        self.join_ID_entry = None
        self.join_count = 0

        # 메인 화면
        self.mainWindow = None
        self.title = None
        self.color1_label = None
        self.color2_label = None
        self.color3_label = None
        self.sub_title = None
        self.search_entry = None
        self.search_btn = None
        self.book = None
        self.ranking_book = None
        self.New_book = None
        self.my_library = None
        self.daejeon = None
        self.hope_book = None
        self.Message = None
        self.use_question = None
        self.QNA = None
        self.book_image = None
        self.ranking_book_image = None
        self.New_book_image = None
        self.my_library_image = None
        self.exit_label = None

        # 전자책 클릭시 나타나는 화면
        self.e_bookWindow = None
        self.text_title = None
        self.text1 = None
        self.text2 = None
        self.text3 = None
        self.text4 = None
        self.text5 = None
        self.combo_search_btn = None
        self.book_listbox = None
        self.combo = None
        self.color4_Label = None
        self.choice_label = None

        # 책 선택하기 클릭시 나타나는 화면
        self.e_book_choiceWindow = None
        self.boder_label = None
        self.boder2_label = None
        self.choice_book_image = None
        self.boder_text_label = None

        self.book_title_label = None
        self.book_title_name = None
        self.book_writer = None
        self.book_writer_name = None
        self.book_publisher = None
        self.book_publisher_name = None
        self.book_date = None
        self.book_date_name = None
        self.book_content = None
        self.book_content_name = None
        self.e_book_img = None
        self.shopping_basket = None
        self.rental = None
        self.exit = None

        # 도서 랭킹 클릭시 나타나는 화면
        self.ranking_Window = None
        self.canvas2 = None
        self.btn_frame = None
        # 전체 이미지
        self.all_frame = None

        # 반납 화면
        self.return_Window = None
        self.return_title = None
        self.return_stick = None
        self.return_canvas = None
        self.return_state_btn = None
        self.return_hope_btn = None

        self.return_state_text1 = None
        self.return_state_text2 = None
        self.return_state_text3 = None
        self.return_state_text4 = None
        self.return_state_text5 = None
        self.return_state_text6 = None
        self.return_state_text7 = None
        self.return_state_text8 = None
        self.return_state_text9 = None

        self.return_btn1 = None
        self.return_btn2 = None
        self.return_btn3 = None

        self.extension_btn1 = None
        self.extension_btn2 = None
        self.extension_btn3 = None

        # 라벨 클릭시
        self.all_btn_label = None
        self.essay_btn_label = None
        self.travel_btn_label = None
        self.fiction_btn_label = None
        self.IT_btn_label = None
        self.child_btn_label = None

        self.image_all_rank1 = None
        self.image_all_rank2 = None
        self.image_all_rank3 = None
        self.image_all_rank4 = None
        self.image_all_rank5 = None
        self.image_all_rank6 = None

        self.all_rank1_label = None
        self.all_rank2_label = None
        self.all_rank3_label = None
        self.all_rank4_label = None
        self.all_rank5_label = None
        self.all_rank6_label = None

        self.all_text1 = None
        self.all_text2 = None
        self.all_text3 = None
        self.all_text4 = None
        self.all_text5 = None
        self.all_text6 = None

        # 에쎄이
        self.essay_frame = None
        self.essay_label = None
        self.image_essay_rank1 = None
        self.essay_text = None
        self.essay_photo = None
        # 소설
        self.fiction_frame = None
        self.fiction_label = None
        self.image_ficition_rank1 = None
        self.fiction_text = None
        self.fiction_photo = None
        # 여행
        self.travel_frame = None
        self.travel_label = None
        self.image_travel_rank1 = None
        self.travel_text = None
        self.travel_photo = None
        # IT
        self.IT_frame = None
        self.IT_label = None
        self.image_IT_rank1 = None
        self.IT_text = None
        self.IT_photo = None
        #child
        self.child_frame = None
        self.child_label = None
        self.image_child_rank1 = None
        self.child_text = None
        self.child_photo = None

        self.y = 0

    def conn(self):       # 서버 연결
        self.conn_soc = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
        self.conn_soc.connect((UserClient.HOST,UserClient.PORT))

    def center_window(self,x,y,frame):        # 화면 중앙에 놓기
        window_x = x
        window_y = y

        total_x = self.window.winfo_screenwidth()
        total_y = self.window.winfo_screenheight()

        x_poy = int((total_x/2) - (window_x/2))
        y_poy = int((total_y/2) - (window_y/2))

        frame.geometry(f"{window_x}x{window_y}+{x_poy}+{y_poy}")

    def make_login_tk(self):   # 로그인 프레임
        self.window = Tk()
        self.window.title("Login")
        self.window.resizable(False,False)

        self.photo = ImageTk.PhotoImage(Image.open("Login_img.jpg"))
        self.photo2 = ImageTk.PhotoImage(Image.open("search2.png"))
        self.photo3 = ImageTk.PhotoImage(Image.open("book.png"))
        self.photo4 = ImageTk.PhotoImage(Image.open("ranking.png"))
        self.photo5 = ImageTk.PhotoImage(Image.open("New_book.png"))
        self.photo6 = ImageTk.PhotoImage(Image.open("my_library.png"))
        self.photo7 = ImageTk.PhotoImage(Image.open("hope.png"))
        self.photo8 = ImageTk.PhotoImage(Image.open("use.png"))
        self.photo9 = ImageTk.PhotoImage(Image.open("daejeon.png"))
        self.photo10 = ImageTk.PhotoImage(Image.open("message.png"))
        self.photo11 = ImageTk.PhotoImage(Image.open("Q_A.png"))
        self.photo12 = ImageTk.PhotoImage(Image.open("monitor.png"))

        self.canvas = Canvas(self.window, width=400, height=450, bg = 'white')
        self.canvas.grid(row=0,column=0)
        self.canvas.create_image(0,0,anchor=NW,image=self.photo)

        self.id_entry = Entry(self.window)
        self.pw_entry = Entry(self.window,show='*')

        self.id_entry.place(x=125, y=150)
        self.pw_entry.place(x=125,y=200)

        self.btn1 = Button(self.window, width=15, height=0, text="Login", command=self.login).place(x=140, y=250)
        self.join_membership = Label(self.window,text='회원가입')
        self.join_membership.place(x=340,y=5)

        self.join_membership.bind("<Button-1>",self.join_member_click)

        self.center_window(400,450,self.window)

    def Join_Membership_Window(self,num):       # 회원가입 화면
        if num == 0 :
            self.joinWindow = Toplevel(self.window)
            self.joinWindow.title('Join')
            self.joinWindow.resizable(False,False)
            self.center_window(400, 450, self.joinWindow)

            self.join_name_entry = Entry(self.joinWindow)
            self.join_ID_entry = Entry(self.joinWindow)
            self.join_PW_entry = Entry(self.joinWindow)
            self.join_name_entry.place(x=125,y=100)
            self.join_ID_entry.place(x=125,y=150)
            self.join_PW_entry.place(x=125,y=200)

            self.join_name_label = Label(self.joinWindow, text='이름')
            self.join_ID_label = Label(self.joinWindow,text='아이디')
            self.join_PW_label = Label(self.joinWindow, text='비밀번호')
            self.join_name_label.place(x=90,y=100)
            self.join_ID_label.place(x=80,y=150)
            self.join_PW_label.place(x=70,y=200)

            self.join_btn = Button(self.joinWindow,width=15,height=0,text="회원가입",command=self.checking_membership)
            self.join_btn.place(x=140,y=250)
        else :
            msgbox.showwarning('경고','이미 가입했잖아요')

    def join_member_click(self,event):  # 로그인화면 -> 회원가입 클릭시
        self.Join_Membership_Window(self.join_count)

    def checking_membership(self):   # 회원가입 (중복체크)
            name = self.join_name_entry.get()
            UserClient.id_data = self.join_ID_entry.get()
            UserClient.pw_data = self.join_PW_entry.get()
            if len(UserClient.id_data) >= 8 :
                msgbox.showinfo('안내','ID 최대 글자 수 초과',parent=self.joinWindow)
            if len(UserClient.pw_data) >= 8 :
                msgbox.showinfo('안내', 'PW 최대 글자 수 초과',parent=self.joinWindow)
            else :
                join_data ='회'+' '+name+" "+UserClient.id_data+" "+UserClient.pw_data
                return self.conn_soc.send(join_data.encode('utf-8'))

    def main_window(self):        # 메인 프레임
        self.mainWindow = Toplevel(self.window)
        self.mainWindow.title("Main")
        self.mainWindow.resizable(False,False)
        self.center_window(500,800,self.mainWindow)
        self.canvas = Canvas(self.mainWindow, width=500, height=800, bg = "white")
        self.canvas.grid(row=0,column=0)

        self.exit_photo = ImageTk.PhotoImage(Image.open("exit.png"))
        # 제목 타이틀
        self.title = Label(self.mainWindow, text="대전 스마트 도서관", width=38, height=1, font=('Terminal', 20, 'bold'),fg='dodgerblue', bg='white').place(x=0, y=1)
        self.sub_title = Label(self.mainWindow, text="Daejeon Samrt Library", width=83, height=0, font=('Terminal', 11),fg='dodgerblue', bg="white").place(x=0, y=31)
        self.exit_label = Label(self.mainWindow,image=self.exit_photo,bg='white',width=50,height=50)
        self.exit_label.place(x=450,y=1)
        # 배경 색상 라벨들
        self.color1_label = Label(self.mainWindow,bg="dodgerblue",width=72,height=4).place(x=0,y=55)
        self.color2_label = Label(self.mainWindow, bg='dodgerblue', width=72, height=16).place(x=0, y=300)
        self.color3_label = Label(self.mainWindow,bg='limegreen',width=72,height=17).place(x=0,y=546)

        # 검색창 기능
        self.search_entry = Entry(self.mainWindow,font=('돋움체',20))
        self.search_entry.place(x=10,y=63,width=480,height=50)

        self.search_btn = Button(self.mainWindow,image=self.photo2,bg='dodgerblue')
        self.search_btn.place(x= 440, y= 63,width=60,height=50)

        # 아래 하단 아이콘들 (-파란부분)
        self.book = Label(self.mainWindow,text="전자책",anchor=S,font=('Terminal',15,'bold'),fg='white',bg='dodgerblue',width=12,height=10)
        self.ranking_book = Label(self.mainWindow,text="도서 순위",anchor=S,font=('Terminal',15,'bold'),fg='white',bg='dodgerblue',width=12,height=10)
        self.New_book = Label(self.mainWindow,text="신작 도서",anchor=S,font=('Terminal',15,'bold'),fg='white',bg='dodgerblue',width=12,height=10)
        # 아래 하단 아이콘 (이미지 - 파란부분)
        self.book_image = Label(self.mainWindow,image=self.photo3,width=110,height=110,bg='dodgerblue')
        self.ranking_book_image = Label(self.mainWindow, image=self.photo4, width=110, height=110, bg='dodgerblue')
        self.New_book_image = Label(self.mainWindow, image=self.photo5, width=110, height=110, bg='dodgerblue')
        # 아래 하단 아이콘들 (-초록부분)
        self.my_library = Label(self.mainWindow,text="나만의 도서관",font=('Terminal',12,'bold'),fg='white',anchor=E,bg='limegreen',width=16,height=3)
        self.hope_book = Label(self.mainWindow,text="희망도서신청",fg='white',font=('Terminal',12,'bold'),anchor=E,bg='limegreen',width=16,height=3)
        self.use_question = Label(self.mainWindow,text="이용 문의",fg='white',font=('Terminal',12,'bold'),anchor=E,bg='limegreen',width=16,height=3)
        self.daejeon = Label(self.mainWindow,text="대전의 자랑",fg='white',font=('Terminal',12,'bold'),anchor=E,bg='limegreen',width=16,height=3)
        self.Message = Label(self.mainWindow,text="메 시 지",fg='white',font=('Terminal',12,'bold'),anchor=E,bg='limegreen',width=16,height=3)
        self.QNA = Label(self.mainWindow,text="Q n A",fg='white',font=('Terminal',12,'bold'),anchor=E,bg='limegreen',width=16,height=3)
        # 아래 하단 이미지들 (-초록부분)
        self.my_library_image = Label(self.mainWindow,image=self.photo6,anchor=CENTER,width=50,height=50,bg='limegreen')
        self.hope_book_image = Label(self.mainWindow,image=self.photo7,anchor=CENTER,width=50,height=50,bg='limegreen')
        self.use_question_image = Label(self.mainWindow,image=self.photo8,anchor=CENTER,width=50,height=50,bg='limegreen')
        self.daejeon_image = Label(self.mainWindow,image=self.photo9,anchor=CENTER,width=50,height=50,bg='limegreen')
        self.Message_image = Label(self.mainWindow,image=self.photo10,anchor=CENTER,width=50,height=50,bg='limegreen')
        self.QNA_image = Label(self.mainWindow,image=self.photo11,anchor=CENTER,width=50,height=50,bg='limegreen')
        # 클릭 이벤트 (파란배경 - 전자책 클릭시)
        self.book.bind("<Button-1>",self.book_click)
        self.book_image.bind("<Button-1>",self.book_click)
        self.ranking_book.bind("<Button-1>",self.ranking_click)
        self.ranking_book_image.bind("<Button-1>",self.ranking_click)
        self.exit_label.bind("<Button-1>",self.Exit)
        # 클릭 이벤트 (초록배경 - 메시지 클릭시)
        self.Message.bind("<Button-1>",self.message_info)
        self.Message_image.bind("<Button-1>",self.message_info)
        self.my_library.bind("<Button-1>",self.my_library_click)
        self.my_library_image.bind("<Button-1>",self.my_library_click)

        # 라벨 위치
        self.book.place(x=33,y=330)
        self.book_image.place(x=33,y=360)

        self.ranking_book.place(x=197,y=330)
        self.ranking_book_image.place(x=197,y=360)

        self.New_book.place(x=360,y=330)
        self.New_book_image.place(x=360,y=360)

        self.my_library.place(x=33,y=570)
        self.my_library_image.place(x=33,y=570)

        self.hope_book.place(x=33,y=645)
        self.hope_book_image.place(x=33,y=645)

        self.use_question.place(x=33,y=725)
        self.use_question_image.place(x=33,y=725)

        self.daejeon.place(x=285,y=570)
        self.daejeon_image.place(x=285,y=570)

        self.Message.place(x=285,y=645)
        self.Message_image.place(x=285,y=645)

        self.QNA.place(x=285,y=725)
        self.QNA_image.place(x=285,y=725)

    def book_return(self):    # 반납 화면
        self.return_Window = Toplevel(self.window)
        self.return_Window.title("return")
        self.center_window(500,800,self.return_Window)
        self.return_canvas = Canvas(self.return_Window, width=500, height=800, bg = "white")
        self.return_canvas.grid(row=0,column=0)

        # 제목 타이틀
        self.return_title = Label(self.return_Window,text="대 출 현 황",width=25,height=1,font=('HY견명조',20,'bold'),
                                  fg='black',bg='white').place(x=0, y=1)
        self.return_stick = Frame(self.return_Window,width=500,height=1,bg='black').place(x=0,y=35)

        # 버튼 현황
        self.return_state_btn = Label(self.return_Window,text="현   황",font=('HY견명조',12),bg='white',
                                      width=14,height=3,borderwidth=2,highlightbackground='gainsboro',highlightthickness=1)
        self.return_hope_btn = Label(self.return_Window,text="찜 목 록",font=('HY견명조',12),bg='white',
                                      width=14,height=3,borderwidth=2,highlightbackground='gainsboro',highlightthickness=1)
        self.return_app_state_btn = Label(self.return_Window,text="신 청 내 역",font=('HY견명조',12),bg='white',
                                      width=14,height=3,borderwidth=2,highlightbackground='gainsboro',highlightthickness=1)
        self.return_state_click = Frame(self.return_Window,width=161,height=3,bg='black')
        self.return_hope_click = Frame(self.return_Window,width=161,height=3,bg='black')
        self.return_app_state_click = Frame(self.return_Window,width=161,height=3,bg='black')

        self.return_bar = Frame(self.return_Window,width=500,height=2,bg='gainsboro')

        self.return_state_frame = Frame(self.return_Window,width=500,height=650,bg='white')
        self.return_state_bar1 = Frame(self.return_state_frame,width=500,height=2,bg='gainsboro')
        self.return_state_bar2 = Frame(self.return_state_frame, width=500, height=2, bg='gainsboro')
        # 1번째 대여란 ---------------------------------------------------------------------
        self.return_state_bar3 = Frame(self.return_state_frame,width=460,height=2,bg='gainsboro')
        self.return_state_bar4 = Frame(self.return_state_frame,width=460,height=2,bg='gainsboro')
        self.return_state_bar5 = Frame(self.return_state_frame,width=2,height=80,bg='gainsboro')
        self.return_state_bar6 = Frame(self.return_state_frame,width=2,height=80,bg='gainsboro')
        self.return_state_bar7 = Frame(self.return_state_frame, width=460, height=2, bg='gainsboro')
        self.return_state_bar8 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar9 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar10 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')

        self.return_state_label1 = Label(self.return_state_frame,bg='white',text='대여일',width=15,height=2)
        self.return_state_label2 = Label(self.return_state_frame,bg='white',text='반납일',width=15,height=2)
        self.return_state_label3 = Label(self.return_state_frame,bg='white',text='연장신청',width=15,height=2)
        self.return_state_label4 = Label(self.return_state_frame,bg='white',text='반 납',width=15,height=2)

        self.return_state_text_label1 = Label(self.return_state_frame,text=self.return_state_text1,bg='white')
        self.return_state_text_label2 = Label(self.return_state_frame,text=self.return_state_text2,bg='white',width=15, height=2)
        self.return_state_text_label3 = Label(self.return_state_frame,text=self.return_state_text3,bg='white',width=15, height=2)

        self.return_btn1 = Button(self.return_state_frame,text='반 납',width=14,height=1,bg='limegreen',command=self.line_1_return)
        self.extension_btn1 = Button(self.return_state_frame, text='연 장', width=14, height=1, bg='limegreen')
        # 2번째 대여란 ---------------------------------------------------------------------
        self.return_state_bar11 = Frame(self.return_state_frame, width=460, height=2, bg='gainsboro')
        self.return_state_bar12 = Frame(self.return_state_frame, width=460, height=2, bg='gainsboro')
        self.return_state_bar13 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar14 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar15 = Frame(self.return_state_frame, width=460, height=2, bg='gainsboro')
        self.return_state_bar16 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar17 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar18 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')

        self.return_state_label5 = Label(self.return_state_frame,bg='white',text='대여일',width=15,height=2)
        self.return_state_label6 = Label(self.return_state_frame, bg='white', text='반납일', width=15, height=2)
        self.return_state_label7 = Label(self.return_state_frame, bg='white', text='연장신청', width=15, height=2)
        self.return_state_label8 = Label(self.return_state_frame, bg='white', text='반 납', width=15, height=2)

        self.return_state_text_label4 = Label(self.return_state_frame,text=self.return_state_text4,bg='white')
        self.return_state_text_label5 = Label(self.return_state_frame,text=self.return_state_text5,bg='white',width=15, height=2)
        self.return_state_text_label6 = Label(self.return_state_frame,text=self.return_state_text6,bg='white',width=15, height=2)

        self.return_btn2 = Button(self.return_state_frame, text='반 납', width=14, height=1, bg='limegreen',command=self.line_2_return)
        self.extension_btn2 = Button(self.return_state_frame, text='연 장', width=14, height=1, bg='limegreen')
        # 3번째 대여란 ---------------------------------------------------------------------
        self.return_state_bar19 = Frame(self.return_state_frame, width=460, height=2, bg='gainsboro')
        self.return_state_bar20 = Frame(self.return_state_frame, width=460, height=2, bg='gainsboro')
        self.return_state_bar21 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar22 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar23 = Frame(self.return_state_frame, width=460, height=2, bg='gainsboro')
        self.return_state_bar24 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar25 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')
        self.return_state_bar26 = Frame(self.return_state_frame, width=2, height=80, bg='gainsboro')

        self.return_state_label9 = Label(self.return_state_frame, bg='white', text='대여일', width=15, height=2)
        self.return_state_label10 = Label(self.return_state_frame, bg='white', text='반납일', width=15, height=2)
        self.return_state_label11 = Label(self.return_state_frame, bg='white', text='연장신청', width=15, height=2)
        self.return_state_label12 = Label(self.return_state_frame, bg='white', text='반 납', width=15, height=2)

        self.return_state_text_label7 = Label(self.return_state_frame,text=self.return_state_text7,bg='white')
        self.return_state_text_label8 = Label(self.return_state_frame,text=self.return_state_text8,bg='white',width=15, height=2)
        self.return_state_text_label9 = Label(self.return_state_frame,text=self.return_state_text9,bg='white',width=15, height=2)

        self.return_btn3 = Button(self.return_state_frame, text='반 납', width=14, height=1, bg='limegreen',command=self.line_3_return)
        self.extension_btn3 = Button(self.return_state_frame, text='연 장', width=14, height=1, bg='limegreen')
        # ----------------------------------------------------------------------------------
        self.return_state_btn.place(x=3,y=90)
        self.return_hope_btn.place(x=168,y=90)
        self.return_app_state_btn.place(x=333,y=90)

        self.return_state_click.place(x=3,y=142)
        self.return_hope_click.place(x=168,y=142)
        self.return_app_state_click.place(x=333,y=142)

        self.return_bar.place(x=0,y=160)
        self.return_state_frame.place(x=0,y=161)
        # 1번째 대여란 ---------------------------------------------------------------------
        self.return_state_bar1.place(x=0,y=215)
        self.return_state_bar2.place(x=0, y=430)

        self.return_state_bar3.place(x=20,y=120)
        self.return_state_bar7.place(x=20,y=160)
        self.return_state_bar4.place(x=20,y=200)

        self.return_state_bar5.place(x=20,y=120)
        self.return_state_bar6.place(x=478,y=120)
        self.return_state_bar8.place(x=135,y=120)
        self.return_state_bar9.place(x=250,y=120)
        self.return_state_bar10.place(x=365,y=120)

        self.return_state_label1.place(x=23,y=123)
        self.return_state_label2.place(x=138,y=123)
        self.return_state_label3.place(x=253,y=123)
        self.return_state_label4.place(x=368,y=123)

        self.return_state_text_label1.place(x=138,y=10)
        self.return_state_text_label2.place(x=23,y=163)
        self.return_state_text_label3.place(x=138,y=163)
        self.return_btn1.place(x=368,y=168)
        self.extension_btn1.place(x=253,y=168)
        # 2번째 대여란 ---------------------------------------------------------------------
        self.return_state_bar11.place(x=20,y=335)
        self.return_state_bar15.place(x=20,y=375)
        self.return_state_bar12.place(x=20,y=415)
        self.return_state_bar13.place(x=20,y=335)
        self.return_state_bar14.place(x=478,y=335)
        self.return_state_bar16.place(x=135,y=335)
        self.return_state_bar17.place(x=250,y=335)
        self.return_state_bar18.place(x=365,y=335)

        self.return_state_label5.place(x=23,y=338)
        self.return_state_label6.place(x=138,y=338)
        self.return_state_label7.place(x=253,y=338)
        self.return_state_label8.place(x=368,y=338)

        self.return_state_text_label4.place(x=138,y=225)
        self.return_state_text_label5.place(x=23,y=378)
        self.return_state_text_label6.place(x=138,y=378)
        self.return_btn2.place(x=368,y=383)
        self.extension_btn2.place(x=253,y=383)
        # 3번째 대여란 ---------------------------------------------------------------------
        self.return_state_bar19.place(x=20,y=545)
        self.return_state_bar23.place(x=20,y=585)
        self.return_state_bar20.place(x=20,y=625)
        self.return_state_bar21.place(x=20,y=545)
        self.return_state_bar22.place(x=478,y=545)
        self.return_state_bar24.place(x=135,y=545)
        self.return_state_bar25.place(x=250,y=545)
        self.return_state_bar26.place(x=365,y=545)

        self.return_state_label9.place(x=23,y=548)
        self.return_state_label10.place(x=138,y=548)
        self.return_state_label11.place(x=253,y=548)
        self.return_state_label12.place(x=368,y=548)

        self.return_state_text_label7.place(x=138,y=440)
        self.return_state_text_label8.place(x=23,y=588)
        self.return_state_text_label9.place(x=138,y=588)
        self.return_btn3.place(x=368,y=593)
        self.extension_btn3.place(x=253,y=593)

    def e_book_window(self):   # 전자책 화면
        self.e_bookWindow = Toplevel(self.window)
        self.e_bookWindow.title("e-book")
        self.e_bookWindow.resizable(False,False)
        self.center_window(500, 800, self.e_bookWindow)
        self.canvas = Canvas(self.e_bookWindow, width=500, height=800, bg = "white")
        self.canvas.grid(row=0,column=0)
        #제목 타이틀
        self.title = Label(self.e_bookWindow, text="대전 스마트 도서관", width=38, height=1, font=('Terminal', 20, 'bold'),fg='dodgerblue', bg='white').place(x=0, y=1)
        self.sub_title = Label(self.e_bookWindow, text="Daejeon Samrt Library", width=83, height=0, font=('Terminal', 11),fg='dodgerblue', bg="white").place(x=0, y=31)
        #바탕색 라벨
        self.color1_label = Label(self.e_bookWindow,bg='dodgerblue',width=72,height=10).place(x=0,y=80)
        self.color2_label = Label(self.e_bookWindow,image=self.photo12,bg='dodgerblue',width=150,height=150,anchor=CENTER).place(x=40,y=80)
        # 안내문구 텍스트
        self.text_title = Label(self.e_bookWindow,text="일반전자책",font=('Terminal',17,'bold'),fg='white',bg='dodgerblue')
        self.text1 = Label(self.e_bookWindow,text="일반 전자책은 도서관이 소지하고 있는",font=('Terminal',11),anchor=W,fg='white',bg='dodgerblue')
        self.text2 = Label(self.e_bookWindow, text="전자책으로 최대 동시 3권이 대여 가능한", font=('Terminal', 11), anchor=W, fg='white',bg='dodgerblue')
        self.text3 = Label(self.e_bookWindow, text="도서 대여 시스템입니다", font=('Terminal', 11), anchor=W, fg='white',bg='dodgerblue')
        self.text4 = Label(self.e_bookWindow,text="전자책 자료검색",font=('Terminal',17,'bold'),fg='dodgerblue',bg='white')
        self.text5 = Label(self.e_bookWindow,text="도서 리스트",font=('Terminal',17,'bold'),fg='dodgerblue',bg='white')

        self.text_title.place(x=220,y=90)
        self.text1.place(x=220,y=130)
        self.text2.place(x=220,y=160)
        self.text3.place(x=220,y=190)
        self.text4.place(x=20,y=250)
        self.text5.place(x=20,y=435)
        # 바탕색 만들기
        self.color3_label = Label(self.e_bookWindow,bg='lightblue',width=72,height=8)
        self.color4_Label = Label(self.e_bookWindow,bg='limegreen',width=72,height=30)
        self.color3_label.place(x=0,y=290)
        self.color4_Label.place(x=0,y=470)
        # 콤보박스 만들기
        self.combo = ttk.Combobox(self.e_bookWindow)
        self.combo.config(height=len(UserClient.combo_list), width=18)
        self.combo.config(values=UserClient.combo_list)
        self.combo.config(font=('돋움체', 12))
        self.combo.config(state='readonly')
        self.combo.set("도서 종류 선택")
        self.combo.place(x=130, y=340)
        # 콤보박스 버튼
        self.combo_search_btn = Button(self.e_bookWindow,command=self.check_combo,bg='lightblue',text="검 색",fg='white',font=('돋움체',12,'bold'))
        self.combo_search_btn.place(x=300,y=337)
        # 책 리스트박스
        self.book_listbox = Listbox(self.e_bookWindow,selectmode='single',width=57,height=15,font=('돋움체',11))
        self.book_listbox.place(x=20,y=500)
        # 책 리스트박스 선택 라벨
        self.choice_label = Label(self.e_bookWindow,text="선택하기",font=('Terminal',13),fg='white',bg='limegreen')
        self.choice_label.place(x=418,y=750)
        # 선택하기 라벨 클릭시 이벤트
        self.choice_label.bind("<Button-1>",self.book_choice_click)

    def e_book_CoiceWindow(self):  # 전자책 상세정보 화면
        try :
            # 화면 구성
            self.photo13 = ImageTk.PhotoImage(self.e_book_img)
            self.e_book_choiceWindow = Toplevel(self.window)
            self.e_book_choiceWindow.title("choice")
            self.e_book_choiceWindow.resizable(False,False)
            self.center_window(500, 800, self.e_book_choiceWindow)
            self.canvas = Canvas(self.e_book_choiceWindow, width=500, height=800, bg="white")
            self.canvas.grid(row=0, column=0)
            # 테두리 라벨
            self.boder_label = Label(self.e_book_choiceWindow,width=65,height=48,bg='black')
            self.boder_text_label = Label(self.e_book_choiceWindow,width=63,height=47,bg='white')
            self.book_title_label = Label(self.e_book_choiceWindow,text=self.book_title_name,font=('HY견명조', 16, 'bold'), width=27, height=2,bg='white')
            self.boder_label.place(x=20,y=20)
            self.boder_text_label.place(x=26,y=26)
            self.book_title_label.place(x=31,y=28)
            # 책 이미지 들어갈 라벨
            self.choice_book_image = Label(self.e_book_choiceWindow,image=self.photo13,width=200,height=250,bg='black')
            self.choice_book_image.place(x=145,y=100)
            # 책 정보 들어갈 라벨
            self.book_writer = Label(self.e_book_choiceWindow,text="저 자 :",font=('HY견명조',11),bg='white')
            self.book_writer_name = Label(self.e_book_choiceWindow,text=self.book_writer_name,
                                          font=("HY견명조",11),bg='white')
            self.book_publisher = Label(self.e_book_choiceWindow,text ="출판사 :",font=('HY견명조',11),bg='white')
            self.book_publisher_name = Label(self.e_book_choiceWindow,text=self.book_publisher_name,
                                             font=("HY견명조",11),bg='white')
            self.book_date = Label(self.e_book_choiceWindow,text="출간일 :",font=('HY견명조',11),bg='white')
            self.book_date_name = Label(self.e_book_choiceWindow,text=self.book_date_name,
                                        font=("HY견명조",11),bg='white')
            self.book_content = Label(self.e_book_choiceWindow,text="=== 도서정보 ========================="
                                                            ,font=('HY견명조',11),bg='white')
            self.book_content_name = Label(self.e_book_choiceWindow,text=self.book_content_name,font=('HY견명조',11),
                                           width=40,height=10,bg='white')
            self.shopping_basket = Label(self.e_book_choiceWindow,text="찜 ♡",font=('HY견명조',11,'bold'),
                                         width=5,height=2,bg='dodgerblue',fg='white')
            self.rental = Label(self.e_book_choiceWindow,text="대 여",font=('HY견명조',11,'bold'),
                                width=5,height=2,bg='lightskyblue',fg='white')
            self.exit = Label(self.e_book_choiceWindow,text="나가기",font=('HY견명조',11,'bold'),
                              width=5,height=2,bg='powderblue',fg='white')
            self.book_writer.place(x=50,y=390)
            self.book_writer_name.place(x=100,y=390)
            self.book_publisher.place(x=40,y=440)
            self.book_publisher_name.place(x=100,y=440)
            self.book_date.place(x=40,y=490)
            self.book_date_name.place(x=100,y=490)
            self.book_content.place(x=40,y=540)
            self.book_content_name.place(x=26,y=560)
            self.shopping_basket.place(x=255,y=750)
            self.rental.place(x=335,y=750)
            self.exit.place(x=415,y=750)
            # 클릭 이벤트 < 찜, 대여, 나가기 >
            self.shopping_basket.bind("<Button-1>",self.hope_info)
            self.rental.bind("<Button-1>",self.rental_info)
            self.exit.bind("<Button-1>",self.exit_info)
        except :
            msgbox.showinfo("안내", "책을 선택하시지 않았습니다", parent=self.e_bookWindow)

    def All_btn(self):
        point = [0,0, 0,60, 60,0]
        self.all_frame = Frame(self.ranking_Window,bg='white',width=500,height=650)
        self.all_frame.place(x=0,y=150)
        #순위 보여주는 부분 (전체 프레임)
        self.image_all_rank1 = Canvas(self.all_frame,width=145,height=195,bg='white')
        self.image_all_rank1.create_image(75,100,image=self.photo13)
        self.image_all_rank1.create_polygon(point,fill="orange")
        self.image_all_rank1.create_text(18,20,text="1",fill='white',font=('HY견명조',20))
        self.image_all_rank1.place(x=50,y=0)
        self.all_rank1_label = Label(self.all_frame,text=self.all_text1,font=('돋움',13),fg='blue',height=1,bg='white')
        self.all_rank1_label.place(x=50,y=205)

        self.image_all_rank2 = Canvas(self.all_frame,width=145,height=195,bg='white')
        self.image_all_rank2.create_image(75,100,image=self.photo14)
        self.image_all_rank2.create_polygon(point,fill="orange")
        self.image_all_rank2.create_text(18,20,text="2",fill='white',font=('HY견명조',20))
        self.image_all_rank2.place(x=300,y=0)
        self.all_rank2_label = Label(self.all_frame, text=self.all_text2, font=('돋움', 13), fg='blue', height=1, bg='white')
        self.all_rank2_label.place(x=300,y=205)

        self.image_all_rank3 = Canvas(self.all_frame,width=145,height=195,bg='white')
        self.image_all_rank3.create_image(75,100,image=self.photo15)
        self.image_all_rank3.create_polygon(point,fill="orange")
        self.image_all_rank3.create_text(18,20,text="3",fill='white',font=('HY견명조',20))
        self.image_all_rank3.place(x=50,y=240)
        self.all_rank3_label = Label(self.all_frame,text=self.all_text3,font=('돋움',13),fg='blue',height=1,bg='white')
        self.all_rank3_label.place(x=50,y=445)

        self.image_all_rank4 = Canvas(self.all_frame,width=145,height=195,bg='white')
        self.image_all_rank4.create_image(75,100,image=self.photo16)
        self.image_all_rank4.create_polygon(point,fill="darkgray")
        self.image_all_rank4.create_text(18,20,text="4",fill='white',font=('HY견명조',20))
        self.image_all_rank4.place(x=300,y=240)
        self.all_rank4_label = Label(self.all_frame,text=self.all_text4,font=('돋움',13),fg='blue',height=1,bg='white')
        self.all_rank4_label.place(x=300,y=445)

        self.image_all_rank5 = Canvas(self.all_frame, width=145, height=195, bg='white')
        self.image_all_rank5.create_image(75, 100, image=self.photo17)
        self.image_all_rank5.create_polygon(point, fill="darkgray")
        self.image_all_rank5.create_text(18, 20, text="5", fill='white', font=('HY견명조', 20))
        self.image_all_rank5.place(x=50, y=480)
        self.all_rank5_label = Label(self.all_frame,text=self.all_text5,font=('돋움',13),fg='blue',height=1,bg='white')
        self.all_rank5_label.place(x=50,y=685)

        self.image_all_rank6 = Canvas(self.all_frame, width=145, height=195, bg='white')
        self.image_all_rank6.create_image(75, 100, image=self.photo18)
        self.image_all_rank6.create_polygon(point, fill="darkgray")
        self.image_all_rank6.create_text(18, 20, text="6", fill='white', font=('HY견명조', 20))
        self.image_all_rank6.place(x=300, y=480)
        self.all_rank6_label = Label(self.all_frame,text=self.all_text6,font=('돋움',13),fg='blue',height=1,bg='white')
        self.all_rank6_label.place(x=300,y=685)
        self.all_frame.bind("<MouseWheel>", self._on_mousewheel)

    def Essay_btn(self):           # 에쎄이 프레임
        point =[0,0, 0,80, 80,0]
        self.essay_frame = Frame(self.ranking_Window,bg='white',width=500,height=650)
        self.essay_frame.place(x=0,y=150)
        #순위 보여주는 부분 (전체 프레임)
        self.image_essay_rank1 = Canvas(self.essay_frame,width=200,height=300)
        self.image_essay_rank1.create_image(100,150,image=self.essay_photo)
        self.image_essay_rank1.create_polygon(point,fill="orange")
        self.image_essay_rank1.create_text(25,25,text="1",fill='white',font=('HY견명조', 25))
        self.image_essay_rank1.place(x=145,y=40)
        self.essay_label = Label(self.essay_frame,text=self.essay_text,
                                 font=('돋움',17),fg='blue',height=1,width=42,bg='white')
        self.essay_label.place(x=0,y=350)

    def Fiction_btn(self):            # 소설 프레임
        point = [0, 0, 0, 80, 80, 0]
        self.fiction_frame = Frame(self.ranking_Window,bg='white',width=500,height=650)
        self.fiction_frame.place(x=0,y=150)
        # 순위 보여주는 부분 (전체 프레임)
        self.image_ficition_rank1 = Canvas(self.fiction_frame,width=200,height=300)
        self.image_ficition_rank1.create_image(100,150,image=self.fiction_photo)
        self.image_ficition_rank1.create_polygon(point,fill="orange")
        self.image_ficition_rank1.create_text(25,25,text="1",fill='white',font=('HY견명조', 25))
        self.image_ficition_rank1.place(x=145,y=40)
        self.fiction_label =Label(self.fiction_frame,text=self.fiction_text,
                                 font=('돋움',17),fg='blue',height=1,width=42,bg='white')
        self.fiction_label.place(x=0,y=350)

    def Travel_btn(self):               # 여행 프레임
        point = [0, 0, 0, 80, 80, 0]
        self.travel_frame = Frame(self.ranking_Window, bg='white', width=500, height=650)
        self.travel_frame.place(x=0, y=150)
        # 순위 보여주는 부분 (전체 프레임)
        self.image_travel_rank1 = Canvas(self.travel_frame, width=200, height=300)
        self.image_travel_rank1.create_image(100,150,image=self.travel_photo)
        self.image_travel_rank1.create_polygon(point, fill="orange")
        self.image_travel_rank1.create_text(25, 25, text="1", fill='white', font=('HY견명조', 25))
        self.image_travel_rank1.place(x=145, y=40)
        self.travel_label = Label(self.travel_frame,text=self.travel_text,
                                 font=('돋움',17),fg='blue',height=1,width=42,bg='white')
        self.travel_label.place(x=0,y=350)

    def IT_btn(self):                 # IT 프레임
        point = [0, 0, 0, 80, 80, 0]
        self.IT_frame = Frame(self.ranking_Window, bg='white', width=500, height=650)
        self.IT_frame.place(x=0, y=150)
        # 순위 보여주는 부분 (전체 프레임)
        self.image_IT_rank1 = Canvas(self.IT_frame, width=200, height=300)
        self.image_IT_rank1.create_image(100,150,image=self.IT_photo)
        self.image_IT_rank1.create_polygon(point, fill="orange")
        self.image_IT_rank1.create_text(25, 25, text="1", fill='white', font=('HY견명조', 25))
        self.image_IT_rank1.place(x=145, y=40)
        self.IT_label = Label(self.IT_frame,text=self.IT_text,
                                 font=('돋움',17),fg='blue',height=1,width=42,bg='white')
        self.IT_label.place(x=0,y=350)

    def Child_btn(self):          # 어린이 프레임
        point = [0, 0, 0, 80, 80, 0]
        self.child_frame = Frame(self.ranking_Window, bg='white', width=500, height=650)
        self.child_frame.place(x=0, y=150)
        # 순위 보여주는 부분 (전체 프레임)
        self.image_child_rank1 = Canvas(self.child_frame, width=200, height=300)
        self.image_child_rank1.create_image(100,150,image=self.child_photo)
        self.image_child_rank1.create_polygon(point, fill="orange")
        self.image_child_rank1.create_text(25, 25, text="1", fill='white', font=('HY견명조', 25))
        self.image_child_rank1.place(x=145, y=40)
        self.child_label = Label(self.child_frame,text=self.child_text,
                                 font=('돋움',17),fg='blue',height=1,width=42,bg='white')
        self.child_label.place(x=0,y=350)

    def all_btn_click(self,event):       # 전체
        self.all_btn_label['state'] = 'active'
        self.essay_btn_label['state'] = 'disabled'
        self.fiction_btn_label['state'] = 'disabled'
        self.travel_btn_label['state'] = 'disabled'
        self.IT_btn_label['state'] = 'disabled'
        self.child_btn_label['state'] = 'disabled'
        self.All_btn()

    def Essay_btn_click(self, event):     # 에쎄이
        self.all_btn_label['state'] = 'disabled'
        self.essay_btn_label['state'] = 'active'
        self.fiction_btn_label['state'] = 'disabled'
        self.travel_btn_label['state'] = 'disabled'
        self.IT_btn_label['state'] = 'disabled'
        self.child_btn_label['state'] = 'disabled'
        self.conn_soc.send('R_E'.encode())

    def Fiction_btn_click(self,event):         # 소설
        self.all_btn_label['state'] = 'disabled'
        self.essay_btn_label['state'] = 'disabled'
        self.fiction_btn_label['state'] = 'active'
        self.travel_btn_label['state'] = 'disabled'
        self.IT_btn_label['state'] = 'disabled'
        self.child_btn_label['state'] = 'disabled'
        self.conn_soc.send('R_F'.encode())

    def Travel_btn_click(self,event):       # 여행
        self.all_btn_label['state'] = 'disabled'
        self.essay_btn_label['state'] = 'disabled'
        self.fiction_btn_label['state'] = 'disabled'
        self.travel_btn_label['state'] = 'active'
        self.IT_btn_label['state'] = 'disabled'
        self.child_btn_label['state'] = 'disabled'
        self.conn_soc.send('R_T'.encode())

    def IT_btn_click(self,event):         # IT
        self.conn_soc.send('R_I'.encode())
        self.all_btn_label['state'] = 'disabled'
        self.essay_btn_label['state'] = 'disabled'
        self.fiction_btn_label['state'] = 'disabled'
        self.travel_btn_label['state'] = 'disabled'
        self.IT_btn_label['state'] = 'active'
        self.child_btn_label['state'] = 'disabled'

    def Child_btn_click(self,event):             # 어린이
        self.conn_soc.send('R_C'.encode())
        self.all_btn_label['state'] = 'disabled'
        self.essay_btn_label['state'] = 'disabled'
        self.fiction_btn_label['state'] = 'disabled'
        self.travel_btn_label['state'] = 'disabled'
        self.IT_btn_label['state'] = 'disabled'
        self.child_btn_label['state'] = 'active'

    def Ranking_Window(self):                      # 랭킹화면
        # 화면 구성
        self.ranking_Window = Toplevel(self.window)
        self.ranking_Window.title("Ranking")
        self.center_window(500, 800, self.ranking_Window)
        self.canvas2 = Canvas(self.ranking_Window, width=500, height=800, bg="white")
        self.canvas2.place(x=0,y=0)
        # 모든 프레임 구성
        self.btn_frame = Frame(self.ranking_Window,bg='white',width=500,height=75)
        self.btn_frame.place(x=0,y=50)
        #제목 타이틀
        self.title = Label(self.ranking_Window, text="대전 스마트 도서관", width=38, height=1, font=('Terminal', 20, 'bold'),fg='dodgerblue', bg='white').place(x=0, y=1)
        self.sub_title = Label(self.ranking_Window, text="Daejeon Samrt Library", width=83, height=0, font=('Terminal', 11),fg='dodgerblue', bg="white").place(x=0, y=31)
        #클릭 라벨
        self.all_btn_label = Label(self.btn_frame,state='normal',activebackground='dimgray',activeforeground='white',
                               bg='silver',text="전 체",width=7,height=2,fg='darkgray')
        self.essay_btn_label = Label(self.btn_frame,state='normal',activebackground='dimgray',activeforeground='white',
                                 bg='silver',text="에쎄이",width=7,height=2,fg='darkgray')
        self.fiction_btn_label = Label(self.btn_frame,state='normal',activebackground='dimgray',activeforeground='white',
                                   bg='silver',text="소 설",width=7,height=2,fg='darkgray')
        self.travel_btn_label = Label(self.btn_frame,state='normal',activebackground='dimgray',activeforeground='white',
                                  bg='silver',text="여 행",width=7,height=2,fg='darkgray')
        self.IT_btn_label = Label(self.btn_frame,state='normal',activebackground='dimgray',activeforeground='white',
                              bg='silver',text="I T",width=7,height=2,fg='darkgray')
        self.child_btn_label = Label(self.btn_frame,state='normal',activebackground='dimgray',activeforeground='white',
                                 bg='silver',text="어린이",width=7,height=2,fg='darkgray')

        self.all_btn_label.place(x=10,y=40)
        self.essay_btn_label.place(x=80,y=40)
        self.fiction_btn_label.place(x=150,y=40)
        self.travel_btn_label.place(x=220,y=40)
        self.IT_btn_label.place(x=290,y=40)
        self.child_btn_label.place(x=360,y=40)

        frame = Frame(self.ranking_Window,bg='black',width=460,height=1)
        frame.place(x=10,y=125)
        self.All_btn()
        # 이벤트 함수
        self.all_btn_label.bind("<Button-1>",self.all_btn_click)
        self.essay_btn_label.bind("<Button-1>",self.Essay_btn_click)
        self.fiction_btn_label.bind("<Button-1>",self.Fiction_btn_click)
        self.travel_btn_label.bind("<Button-1>",self.Travel_btn_click)
        self.IT_btn_label.bind("<Button-1>",self.IT_btn_click)
        self.child_btn_label.bind("<Button-1>",self.Child_btn_click)

    def _on_mousewheel(self, event):    # 마우스 휠 움직이는 이벤트
        data_info = self.image_all_rank1.place_info()
        if event.delta < 0 :
            if int(data_info['y']) <= -100 :
                return
            self.y -= 10
            self.all_book_move(self.y)

        else :
            if int(data_info['y']) >= 0 :
                return
            self.y += 10
            self.all_book_move(self.y)

    def all_book_move(self,y):              # 전 체 움직이는 함수
        self.image_all_rank1.place(x=50, y=0 + y)
        self.image_all_rank2.place(x=300, y=0 + y)
        self.image_all_rank3.place(x=50, y=240 + y)
        self.image_all_rank4.place(x=300, y=240 + y)
        self.image_all_rank5.place(x=50, y=480 + y)
        self.image_all_rank6.place(x=300, y=480 + y)

        self.all_rank1_label.place(x=50, y=205 + y)
        self.all_rank2_label.place(x=300, y=205 + y)
        self.all_rank3_label.place(x=50, y=445 + y)
        self.all_rank4_label.place(x=300, y=445 + y)
        self.all_rank5_label.place(x=50, y=685 + y)
        self.all_rank6_label.place(x=300, y=685 + y)

    def Exit(self,event):
        self.conn_soc.send('⊥나가기'.encode())
        self.mainWindow.destroy()

    def login(self):                               # 로그인 체크 함수
        UserClient.id_data = self.id_entry.get()
        UserClient.pw_data = self.pw_entry.get()
        print(self.conn_soc)
        login_data = UserClient.id_data + " " + UserClient.pw_data
        return self.conn_soc.send(login_data.encode('utf-8'))

    def check_combo(self):       # 콤보박스 값 설정후 버튼 클릭 했을때
        UserClient.combo_data = self.combo.get()
        return self.conn_soc.send('('.encode()+UserClient.combo_data.encode('utf-8'))

    def book_click(self,event):      # 전자책 클릭시
        self.e_book_window()

    def line_1_return(self):          # 첫번째 반납 칸
        a = msgbox.askquestion('안내','반납하시겠습니까?',parent=self.return_Window)
        if a == 'yes' :
            if self.return_state_text1 != '-' :
                self.return_Window.destroy()
                self.conn_soc.send('1〃'.encode()+self.return_state_text1.encode())
                self.return_state_text1 = '-'
                self.return_state_text2 = '-'
                self.return_state_text3 = '-'
                self.book_return()
                msgbox.showinfo('안내','반납이 완료되었습니다',parent=self.return_Window)
            else :
                msgbox.showinfo('안내','반납할 책이 없습니다',parent=self.return_Window)

    def line_2_return(self):     # 2번째 반납 버튼
        a = msgbox.askquestion('안내','반납하시겠습니까?',parent=self.return_Window)
        if a == 'yes' :
            if self.return_state_text4 != '-' :
                self.return_Window.destroy()
                self.conn_soc.send('2〃'.encode()+self.return_state_text4.encode())
                self.return_state_text4 = '-'
                self.return_state_text5 = '-'
                self.return_state_text6 = '-'
                self.book_return()
                msgbox.showinfo('안내','반납이 완료되었습니다',parent=self.return_Window)
            else :
                msgbox.showinfo('안내','반납할 책이 없습니다',parent=self.return_Window)

    def line_3_return(self):       # 3번째 반납 버튼
        a = msgbox.askquestion('안내','반납하시겠습니까?',parent=self.return_Window)
        if a == 'yes' :
            if self.return_state_text7 != '-' :
                self.return_Window.destroy()
                self.conn_soc.send('3〃'.encode()+self.return_state_text7.encode())
                self.return_state_text7 = '-'
                self.return_state_text8 = '-'
                self.return_state_text9 = '-'
                self.book_return()
                msgbox.showinfo('안내','반납이 완료되었습니다',parent=self.return_Window)

            else :
                msgbox.showinfo('안내','반납할 책이 없습니다',parent=self.return_Window)

    def ranking_click(self,envet):         # 랭킹화면 클릭시
        self.conn_soc.send('R_A'.encode())

    def book_choice_click(self,event):    # 전자책 -> 선택하기 클릭시
        self.ind = self.book_listbox.curselection()
        self.info = self.book_listbox.get(self.ind[0])
        self.conn_soc.send('/'.encode()+self.info.encode('utf-8'))

    def message_info(self,event):     # 메시지 클릭시
        msgbox.showinfo("안내","준비중입니다",parent=self.mainWindow)

    def my_library_click(self,evnet):
        self.conn_soc.send('♭'.encode())

    def hope_info(self,event):          # 찜 클릭시
        uc = UserClient()
        msgbox.showinfo("완료","찜 목록에 추가되었습니다",parent=self.e_book_choiceWindow)
        self.conn_soc.send(uc.id_data.encode()+"@".encode()+uc.pw_data.encode()+"@".encode()+self.book_title_name.encode())

    def rental_info(self,evnet):        # 대여 클릭시
        a = msgbox.askquestion('info','정말 대여하시겠습니까?',parent=self.e_book_choiceWindow)
        if a == 'yes' :
            self.conn_soc.send('■'.encode()+self.book_title_name.encode())

    def exit_info(self,event):     # 나가기 클릭
        self.e_book_choiceWindow.destroy()

    def add_listbox(self,data):         # 리시트박스 설정하기
        self.book_listbox.delete(0,self.book_listbox.size() - 1)
        self.book_listbox.insert(END,"                       책  이  름                        ")
        self.book_listbox.insert(END,"=========================================================")

        for item in data :
            self.book_listbox.insert(END,item)

    def img_down(self,text):       # 이미지 다운
        b_data = text.encode('ascii')
        bi_data = base64.b64decode(b_data)
        img_value = Image.open(io.BytesIO(bi_data))

        return img_value

    def recv_data(self,socket):   # 데이터 전송받기
        while True :
            d = socket.recv(630784)

            print("---받는 데이터 수신입니다---")
            print(d.decode())

            if "Complete" in d.decode() :       # 로그인 성공
                self.id_entry.delete(0,tkinter.END)
                self.pw_entry.delete(0,tkinter.END)
                self.main_window()

            if 'Exist' == d.decode() :
                self.join_name_entry.delete(0,tkinter.END)
                self.join_ID_entry.delete(0,tkinter.END)
                self.join_PW_entry.delete(0,tkinter.END)
                msgbox.showinfo('안내','이미 존재하는 정보입니다!',parent=self.joinWindow)

            if 'Create' == d.decode() :
                self.join_name_entry.delete(0, tkinter.END)
                self.join_ID_entry.delete(0, tkinter.END)
                self.join_PW_entry.delete(0, tkinter.END)
                msgbox.showinfo('안내','회원가입이 완료되었습니다!',parent=self.joinWindow)
                self.joinWindow.destroy()
                self.join_count = 1

            if '⊥나가기' == d.decode() :
                self.conn_soc.close()
                sys.exit()

            elif '♭' in d.decode() :
                f = d.decode().split('♭')
                if f[0] != '1' :
                    self.return_state_text1 = f[0]
                else :
                    self.return_state_text1 = '-'
                if f[1] != '1' :
                    self.return_state_text2 = f[1]
                else :
                    self.return_state_text2 = '-'
                if f[2] != '1' :
                    self.return_state_text3 = f[2]
                else :
                    self.return_state_text3 = '-'
                if f[3] != '1' :
                    self.return_state_text4 = f[3]
                else :
                    self.return_state_text4 = '-'
                if f[4] != '1' :
                    self.return_state_text5 = f[4]
                else :
                    self.return_state_text5 = '-'
                if f[5] != '1' :
                    self.return_state_text6 = f[5]
                else :
                    self.return_state_text6 = '-'
                if f[6] != '1' :
                    self.return_state_text7 = f[6]
                else :
                    self.return_state_text7 = '-'
                if f[7] != '1' :
                    self.return_state_text8 = f[7]
                else :
                    self.return_state_text8 = '-'
                if f[8] != '1' :
                    self.return_state_text9 = f[8]
                else :
                    self.return_state_text9 = '-'

                self.book_return()

            elif "Error" in d.decode() :            # 로그인 실패
                msgbox.showerror("경고","올바르지 않은 정보입니다")

            elif "*" in d.decode() :               # 리스트박스 출력
                UserClient.book_data_list = d.decode().split('*')
                self.add_listbox(UserClient.book_data_list)


            elif '∥' in d.decode():  # 책 정보 출력
                print('------ + if 문 들어왔습니다 ------')
                d = d.decode().split('∥')
                b_data = d[5].encode('ascii')
                bi_data = base64.b64decode(b_data)
                self.e_book_img = Image.open(io.BytesIO(bi_data))
                self.book_title_name = d[0]
                self.book_writer_name = d[1]
                self.book_publisher_name = d[2]
                self.book_date_name = d[3]
                self.book_content_name = textwrap.fill(d[4], width=20)
                self.e_book_CoiceWindow()

            elif '♧' in d.decode() :
                d = d.decode().split('♧')
                d = list(filter(None,d))
                self.img_down(d[0])
                self.photo13 = ImageTk.PhotoImage(self.img_down(d[0]))
                self.photo14 = ImageTk.PhotoImage(self.img_down(d[1]))
                self.photo15 = ImageTk.PhotoImage(self.img_down(d[2]))
                self.photo16 = ImageTk.PhotoImage(self.img_down(d[3]))
                self.photo17 = ImageTk.PhotoImage(self.img_down(d[4]))
                self.photo18 = ImageTk.PhotoImage(self.img_down(d[5]))
                self.essay_photo = ImageTk.PhotoImage(self.img_down(d[6]))
                self.fiction_photo = ImageTk.PhotoImage(self.img_down(d[7]))
                self.travel_photo = ImageTk.PhotoImage(self.img_down(d[8]))
                self.IT_photo = ImageTk.PhotoImage(self.img_down(d[9]))
                self.child_photo = ImageTk.PhotoImage(self.img_down(d[10]))

            elif '■' in d.decode() :
                if '중' in d.decode() :
                    msgbox.showinfo("안내","이미 대여중인 책입니다",parent=self.e_book_choiceWindow)
                elif '가능' in d.decode() :
                    msgbox.showinfo("안내", "대여 완료 되었습니다", parent=self.e_book_choiceWindow)
                elif '초과' in d.decode() :
                    msgbox.showinfo("안내", "최대 대여 횟수가 초과되었습니다", parent=self.e_book_choiceWindow)

            elif '○' in d.decode() :
                d = d.decode().split('○')
                print(d)
                if d[1] == 'essay' :
                    self.essay_text = d[0]
                    self.Essay_btn()
                elif d[1] == 'fiction' :
                    self.fiction_text = d[0]
                    self.Fiction_btn()
                elif d[1] == 'travel' :
                    self.travel_text = d[0]
                    self.Travel_btn()
                elif d[1] == 'IT' :
                    self.IT_text = d[0]
                    self.IT_btn()
                elif d[1] == 'child' :
                    self.child_text = d[0]
                    self.Child_btn()
                else :
                    c = []
                    for i in d :
                        if len(i) > 9:
                            c.append(i[0:9]+"···")
                        else :
                            c.append(i)
                    self.all_text1 = c[0]
                    self.all_text2 = c[1]
                    self.all_text3 = c[2]
                    self.all_text4 = c[3]
                    self.all_text5 = c[4]
                    self.all_text6 = c[5]
                    self.Ranking_Window()

    def run(self):
        self.conn()
        self.make_login_tk()

        threading.Thread(target=self.recv_data, args=(self.conn_soc,)).start()

        self.window.mainloop()

    def close(self):
        self.conn_soc.close()

def client() :
    conn = UserClient()
    conn.run()

client()