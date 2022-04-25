Feature: AuthTests

Background: 
	Given go to url "https://stepik.org/"
	And wait until page load


@Positive
Scenario: LoginPositive		
	Given login as "7@yan.ru" -> "7@yan.ru"
	Then on catalog page there is title "Онлайн-курсы"
	And on auth page not visible
	
@Positive
Scenario: LoginOut
	Given login as "7@yan.ru" -> "7@yan.ru"
	And on top menu click user image button
	And logout	
	Then on auth page visible

@Negative
Scenario: LoginInWrongLogin
	Given login as "7@" -> "7@yan.ru"
	Then on auth page visible
	Then on auth page there is alert below button ok "Введите часть адреса после символа"