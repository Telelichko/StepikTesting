Feature: CatalogTests

Background: 
	Given go to url "https://stepik.org/"
	And wait until page load
	And login as "7@yan.ru" -> "7@yan.ru"


@Positive
Scenario: CheckFilterPythonCourse
	Given on top menu click user image button
	And on catalog page fill search input -> "Python"
	And on catalog page click button ok
	Then on catalog page there are some courses

@Negative
Scenario: CheckFilterWrongInput
	Given on top menu click user image button
	And on catalog page fill search input -> "sdzfnjkrocnd"
	And on catalog page click button ok
	Then on catalog page there aren't some courses
	And on catalog page there is message -> "ничего не найдено. Попробуйте изменить параметры поиска"