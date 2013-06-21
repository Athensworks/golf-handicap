require 'spec_helper'

describe Score do
  it "should allow you to build a score" do
    score = Score.new(score: 72, rating: 70.0, slope: 121)
    expect(score.score).to eq(72)
    expect(score.rating).to eq(70.0)
    expect(score.slope).to eq(121)
  end
  
  it "should build a score from a JSON parse" do
    json = %q{{
        "par": 70,
        "rating": 70.0,
        "score": 84,
        "slope": 113
    }}
    
    hash = JSON.parse(json)
    score = Score.new(hash)
    
    expect(score.score).to eq(84)
    expect(score.rating).to eq(70.0)
    expect(score.slope).to eq(113)
  end
end