(define (domain CleanerBot)
;; We only require some typing to make this plan faster. We can do without!
	(:requirements :typing)

	;; We have two types: robots and the tiles, both are objects
	(:types robot tile - object)

	;; define all the predicates as they are used in the probem files
	(:predicates
	(robot ?r)
    (tile ?x)
    (tile ?y)
    ;; described what tile a robot is at
    (robot-at ?r ?x)

    ;; indicates that tile ?x is above tile ?y
    (up ?x ?y)

    ;; indicates that tile ?x is below tile ?y
    (down ?x ?y)

    ;; indicates that tile ?x is right of tile ?y
    (right ?x ?y)

    ;; indicates that tile ?x is left of tile ?y
    (left ?x ?y)

    ;; indicates that a tile is clear (robot can move there)
    (clear ?x)

    ;; indicates that a tile is cleaned
    (cleaned ?x)
 	)



(:action clean-up
  :parameters (?r ?x ?y)
  :precondition (and
									(up ?x ?y) ;; indicates c is above y
									(robot-at ?r ?y)
									(not (cleaned ?y))
								)
  :effect (and
							(cleaned ?x)
							(not (clear ?x ?y))
					)
 )


(:action clean-down
  :parameters (?r ?x ?y)
  :precondition (and
									(down ?x ?y)
									(robot-at ?r ?y)
									(not (cleaned ?y))
								)
  :effect (and
							(cleaned ?x)
							(not (clear ?x ?y))
					)
 )


 (:action up
  :parameters (?r ?x ?y)
  :precondition (and
									(up ?x ?y)
									(clear ?x ?y)
									(robot-at ?r ?y)
								)
  :effect (and
							(robot-at ?r ?x)
							(not (robot-at ?r ?y))
           					(not (clear ?y ?x))
					)
 )


(:action down
  :parameters (?r ?y ?x)
  :precondition (and
									(down ?x ?y)
									(clear ?x ?y)
									(robot-at ?r ?y)
								)
  :effect (and
							(robot-at ?r ?x)
							(not (robot-at ?r ?y))
           					(not (clear ?x ?y))
					)
 )

 (:action right
  :parameters (?r ?x ?y)
  :precondition (and
									(right ?x ?y)
									(clear ?x ?y)
									(robot-at ?r ?y)
								)
  :effect (and
							(robot-at ?r ?x)
							(not (robot-at ?r ?y))
           					(not (clear ?x ?y))
					)
 )

 (:action left
  :parameters (?r ?x ?y)
  :precondition (and
									(left ?x ?y)
									(clear ?x ?y)
									(robot-at ?r ?y)
								)
  :effect (and
							(robot-at ?r ?x)
							(not (robot-at ?r ?y))
           					(not (clear ?x ?y))
					)
)

)
