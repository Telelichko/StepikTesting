Feature: MyStudyPage

Background: 
	Given go to url "https://stepik.org/"
	And wait until page load
	And login as "7@yan.ru" -> "7@yan.ru"


@Positive
Scenario: MyStudyPageDisplay
	Given on top menu click on button my study
	Then on my study page there is title "Моё обучение"
	And on my study page there is left menu

@Positive
Scenario: AddNewCourse
	Given on top menu click user image button
	And on catalog page fill search input -> "Python"
	And on catalog page click button ok
	And on catalog page add course from list by number "1"
	And on top menu click on button my study	
	And on top menu click user image button
	And on user menu click button profile
	And on top menu click on button my study
	When on my study page click on button course in progress	
	Then on my study page there is a course in progress "Python"