class Score
  attr_accessor :par, :score, :slope, :rating
  def initialize(options = {})
    options.symbolize_keys!
    @score  = options[:score]
    @slope  = options[:slope]
    @rating = options[:rating]
    @par    = options[:par]
  end
end