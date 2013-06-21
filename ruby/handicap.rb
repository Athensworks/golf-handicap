require 'rubygems'
require 'bundler/setup'

JSON_DATA = "../data/scores.json"

class Golfer
  attr_accessor :name
  
  def initialize(name)
    @name = name
  end
end

