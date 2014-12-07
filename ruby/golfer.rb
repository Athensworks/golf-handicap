class Golfer
  attr_accessor :name

  DIFFERENTIALS =   { 5 => 1,
                      6 => 1,
                      7 => 2,
                      8 => 2,
                      9 => 3,
                      10 => 3,
                      11 => 4,
                      12 => 4,
                      13 => 5,
                      14 => 5,
                      15 => 6,
                      16 => 6,
                      17 => 7,
                      18 => 8,
                      19 => 9,
                      20 => 10 }

  def initialize(name)
    @name = name
    @scores = []
  end

  def add_score(score)
    @scores << score
  end

  def add_scores(scores)
    scores.each {|score|
     add_score(score)
    }
  end

  def import_scores(scores_array)
    scores_array.each{|score_hash|
      add_score(Score.new(score_hash))
    }
  end

  def scores
    @scores
  end

  def handicap
    i = (lowest_differentials.inject(&:+) / lowest_differentials.count) * 0.96
    (i * 10).floor / 10.0
  end

  private

  def lowest_differentials
    raise 'Not enough scores' if scores.count < 5

    index = DIFFERENTIALS[scores.count] || 10
    differentials.sort[0..(index - 1)]
  end

  def differentials
    scores.collect {|score|
      (score.score - score.rating) * 113 / score.slope
    }
  end

end
