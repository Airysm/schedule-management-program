2022-05-14 (유재원)

-코드 설명 (안 읽고 코드보고 이해하셔도 됩니다.)

DB 관련 내용은 Form1.DB.cs에 저장되어 있습니다.
static 클래스로 변경해놓았습니다. 인스턴스 생성 안하시고 쓰시면 됩니다.

flowLayoutPanel에 group box로 일정을 표시합니다.
일정 group box안에는 textBox, edit button, delete button이 들어갑니다.
이것들을 묶어서 '일정Group'이라는 클래스로 만들었습니다.
표시할 일정Group 클래스들은 'groupList'라는 리스트에 저장해줍니다.

flowLayoutPanel이 그룹박스들의 정렬을 자동으로 해줍니다.
따라서 정렬될 그룹박스들의 순서만 정해주면 됩니다.
이 순서를 정해주는 작업을 textBoxAlignment 함수가 해줍니다.

Add 버튼을 누르면 metroButton_Add_Click 함수가 실행됩니다.
이 함수 안에서 group box, textBox, edit button, delete button를 동적으로 생성해줍니다.
//* 로 표시한 부분에서 입력할 내용을 바꿔주시면 됩니다.



-분배 
(~05/20)
유재원 - 달력의 날짜를 누르면 해당 날짜의 일정을 표시하기
다리아 - textBox의 내용이 표시되고, 저장되도록 하기
(~05/27)
유재원 - 체크리스트 만들기
다리아 - 목록 추가 만들기


* 이해 안가는 코드가 있으면 알려주세요.