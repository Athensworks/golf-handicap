require 'spec_helper'

describe Score do
  it "should allow you to build a score" do
    score = Score.new(score: 72, rating: 70.0, slope: 121)
    expect(score.score).to eq(72)
    expect(score.rating).to eq(70.0)
    expect(score.slope).to eq(121)
  end
end