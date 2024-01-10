﻿# FREEINVADERS by :action_27

## Інструкція

### Інсталяція

Інсталяція можлива 2 шляхами.

#### Запуск з рушія

Для запуску з рушія потрібно виконати данні дії:
- Скачати `Godot v4.1.1 Mono` [за посиланням](https://godotengine.org/download/archive/4.1.1-stable/).
- Скачати архів проекту [за посиланням](https://github.com/Pazzann/FreeInvaders).
- Імпортувати проект до рушія.
- Запустити проект натиснувши `▶︎` у правому верхньому кутку екрану.


#### Запуск з виконавчого файла

Для того щоб запустити гру легше, просто скачайте папку з білдом та відкрийте `.exe` файл.

### Керування

Керування у нашій програмі відповідає оригіналу та є дуже простим:
 - Рухатись: `⬅︎` та `➡︎`
 - Стріляти: `Space`

### Правила гри

В грі дуже прості правила відповідно до оригіналу:
- В вас є 3 житті.
- На вас рухається толпа монстрів, які якщо до вас дотянуться ви програли.
- Вам потрібно збивати їх кулями та набирати бали(з кожного супротивника вони випадають по різному).
- У рандомний момент часу може заспавнитися золотий супротивник з якого ми отримаємо випадкову кількість балів.

## Наші нові функції

Ми реалізували декілька додаткових функцій:
 - Босс.

## Документація

### Про проект

Наш проект написаний на рушії `Godot v4.1.1 Mono` з використанням мови програмування `С#`. Ці інструменти були вибрані через гарну ознайомленність з ними членами команди.

### Cцени

В нашому проекті є декілька сцен:
 - `Main.tscn` - Основна сцена гри.
 - `Menu.tscn` - Початкове меню гри.
 - `Bullet.tscn` - Префаб для куль.
 - `House.tscn` - Префаб для захисної споруди.

### Спрайти

В нашому проекті у програмі `Aseprite` були намальована велика кількість спрайтів відповідно до оригіналу, а також додаткові:
 - 2 кадри анімації для кожного супротивника.
 - Додатковий бос.
 - Спрайти для будівлі по 4 життя на кожну захисну споруду.
 - 3 різних вида куль