require 'spec_helper'

describe Golfer do
  
  before(:each) do
    @joe = Golfer.new("Joe")
  end
  
  it "should require a golfer's name" do
    expect(Golfer.new(nil)).to raise_error
  end
  
  it "should create a new golfer" do
    expect(@joe).to be_kind_of(Golfer)
    expect(@joe.name).to eq("Joe")
  end
  
  it "should allow you to append scores" do
    score = Score.new(score: 72, rating: 71, slope: 120)
    expect(@joe.add_score(score)).to include(score)
    expect(@joe.scores).to include(score)
  end

end
