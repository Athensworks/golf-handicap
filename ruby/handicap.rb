require 'rubygems'
require 'bundler/setup'

JSON_DATA = "../data/scores.json"

class Golfer
  attr_accessor :name
  
  def initialize(name)
    @name = name
    @scores = []
  end
  
  def add_score(score)
    @scores << score
  end
  
  def scores
    @scores
  end
end

class Score
  attr_accessor :par, :score, :slope, :rating
  def initialize(options)
    @score = options[:score]
    @slope = options[:slope]
    @rating = options[:rating]
    @par = options[:par]
  end
end

